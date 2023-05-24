using System.Text;
using System.Text.Json;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RabbitMQ.Client;
using api.v1.service.auth.Models;
using db.v1.context.auth.Repos;
using misc.jwt;
namespace api.v1.service.auth.Controllers
{
    /// <summary>
    /// Авторизация пользователя в системе
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class AuthController : ControllerBase, IDisposable
    {
        /// <summary>
        /// Взаимодействие с аккаунтами пользователей
        /// </summary>
        private readonly IAuthRepos _auth;

        /// <summary>
        /// Конфиг с настройками
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// Подключение к брокеру сообщений
        /// </summary>
        private readonly IConnection _connection;

        /// <summary>
        /// Канал связи с сервисом профилей пользователей
        /// </summary>
        private readonly IModel _channel;

        public AuthController(IAuthRepos auth, IConfiguration configuration)
        {
            _auth = auth;
            _config = configuration;

            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(
                exchange: "direct_profiles",
                type: ExchangeType.Direct);
        }



        #region Эндпоинты

        /// <summary>
        /// Регистрация нового пользователя в системе
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользоватея</param>
        /// <param name="surname">Фамилия пользователя</param>
        /// <param name="name">Имя пользователя</param>
        /// <param name="patronymic">Отчество пользователя</param>
        [HttpPost("SignUp")]
        public IActionResult SignUp([FromBody] string email, [FromBody] string password, [FromBody] string surname, [FromBody] string name, [FromBody] string? patronymic)
        {
            switch (_auth.IsEmailBusy(email))
            {
                case true:
                    return StatusCode(406, new { status = "Почта уже занята другим пользователем" });

                case false:
                    int user_id = _auth.AddAccount(email, password);

                    _channel.BasicPublish(
                        exchange: "direct_profiles",
                        routingKey: "create",
                        body: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new { user_id, surname, name, patronymic })));

                    return StatusCode(200, new { status = "Новый аккаунт был успешно зарегистрирован" });
            }
        }

        /// <summary>
        /// Авторизация пользователя в системе
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользоватея</param>
        [HttpPost("SignIn")]
        public IActionResult SignIn([FromBody] string email, [FromBody] string password)
        {
            switch (_auth.IsAccountExist(email, password))
            {
                case true:
                    var user = _auth.GetAccountInfo(email, password)!;

                    var refresh_token = CreateRefreshToken();
                    _auth.AddToken(new(user.ID, refresh_token.Value, refresh_token.Created, refresh_token.Expires));

                    return StatusCode(200, new
                    {
                        status = "Аккаунт был успешно найден",
                        access_token = CreateAccessToken(user.ID.ToString(), user.RoleName)
                    });

                case false:
                    return StatusCode(404, new 
                    { 
                        status = "Аккаунта с заданной почтой и паролем не существует" 
                    });
            }
        }

        /// <summary>
        /// Обновить токен
        /// </summary>
        [HttpPost("Refresh")]
        public IActionResult UpdateRefreshToken()
        {
            var user = _auth.GetAccountInfo(AuthToken.GetUserID(HttpContext.Request))!;
            var refreshToken = Request.Cookies["refresh_token"]!;

            if (!_auth.IsTokenExist(user.ID, refreshToken))
            {
                return StatusCode(404, new
                {
                    status = "Токен не был найден"
                });
            }
            if (!_auth.IsTokenExpired(user.ID, refreshToken))
            {
                return StatusCode(403, new
                {
                    status = "Срок жизни токена истёк"
                });
            }

            var refresh_token = CreateRefreshToken();
            _auth.AddToken(new(user.ID, refresh_token.Value, refresh_token.Created, refresh_token.Expires));

            return StatusCode(200, new
            {
                status = "Токен был успешно обновлён",
                access_token = CreateAccessToken(user.ID.ToString(), user.RoleName)
            });

        }

        #endregion




        /// <summary>
        /// Создать JWT-токен с данными
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="role">Наименование роли</param>
        [NonAction]
        private string CreateAccessToken(string id, string role)
        {
            var claims = new List<Claim> { new(ClaimTypes.Name, id), new(ClaimTypes.Role, role) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!));

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(24),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature));
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Создать refresh токен
        /// </summary>
        [NonAction]
        private RefreshToken CreateRefreshToken()
        {
            var refresh_token = new RefreshToken(Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)), DateTime.Now.AddDays(14), DateTime.Now);
            Response.Cookies.Append("refresh_token", refresh_token.Value, new CookieOptions { HttpOnly = true, Expires = refresh_token.Expires });
            return refresh_token;
        }

        [NonAction]
        public void Dispose()
        {
            if (_connection.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }
    }
}