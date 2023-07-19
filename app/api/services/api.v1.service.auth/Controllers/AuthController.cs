using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MassTransit;
using api.v1.service.auth.Helpers;
using api.v1.service.auth.Models;
using api.v1.service.auth.Models.Requests;
using db.v1.context.auth.Repos;
using db.v1.context.profiles.Models.Profiles.BaseInfo;
using helpers.jwt;
namespace api.v1.service.auth.Controllers
{
    /// <summary>
    /// Авторизация пользователя в системе
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class AuthController : ControllerBase
    {
        /// <summary>
        /// Взаимодействие с аккаунтами пользователей
        /// </summary>
        private readonly IAuthRepos _authRepos;

        /// <summary>
        /// Конфиг с настройками
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// Взаимодействие с другими сервисами
        /// </summary>
        private readonly IBus _bus;

        /// <summary>
        /// Взаимодействие с JWT-токеном
        /// </summary>
        private readonly IAuthServiceToken _jwt;

        /// <summary>
        /// Логгирование текста в консоль
        /// </summary>
        private readonly ILogger _logger;

        public AuthController(IAuthRepos auth, IConfiguration configuration, IBus bus, 
                              IAuthServiceToken jwt, ILogger<AuthController> logger)
        {
            _authRepos = auth;
            _config = configuration;
            _bus = bus;
            _jwt = jwt;
            _logger = logger;
        }



        #region Эндпоинты

        /// <summary>
        /// Регистрация нового пользователя в системе
        /// </summary>
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody][Required] SignUpRequestModel request)
        {
            switch (_authRepos.IsEmailBusy(request.Email))
            {
                case true:
                    return StatusCode(409, new 
                    { 
                        status = "Почта уже занята другим пользователем" 
                    });

                case false:
                    int userID = _authRepos.AddAccount(request.Email, SecurityHelper.HashPassword(request.Email, request.Password));

                    var newProfile = new ProfileBaseInfoModel(userID, request.Surname, request.Name, request.Patronymic);

                    ISendEndpoint endpoint = await _bus.GetSendEndpoint(new Uri("rabbitmq://localhost/profiles_create"));
                    await endpoint.Send(newProfile);

                    return StatusCode(201, new 
                    { 
                        status = "Новый аккаунт был успешно зарегистрирован" 
                    });
            }
        }

        /// <summary>
        /// Авторизация пользователя в системе
        /// </summary>
        [HttpPost("SignIn")]
        //[ValidateAntiForgeryToken]
        public IActionResult SignIn([FromBody][Required] SignInRequestModel request)
        {
            //_logger.LogInformation(
            //    $"\tDate: {DateTime.Now:dd:MM:yyyy}\n" +
            //    $"\tTime: {DateTime.Now:HH:mm:ss:ff}\n" +
            //    $"\tIP: {HttpContext.Connection.RemoteIpAddress}\n" +
            //    $"\tMethod: {HttpContext.Request.Method}\n" +
            //    $"\tEndpoint: {HttpContext.Request.Path}");

            string hashPass = SecurityHelper.HashPassword(request.Email, request.Password);
            switch (_authRepos.IsAccountExist(request.Email, hashPass))
            {
                case true:
                    var user = _authRepos.GetAccountInfo(request.Email, hashPass)!;

                    var refresh_token = CreateRefreshToken();
                    _authRepos.AddToken(new(user.ID, refresh_token.Value, refresh_token.Created, refresh_token.Expires));

                    return StatusCode(200, new
                    {
                        status = "Аккаунт был успешно найден",
                        access_token = CreateAccessToken(user.ID.ToString(), user.RoleName)
                    });

                case false:
                    return StatusCode(204, new 
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
            var user = _authRepos.GetAccountInfo(_jwt.GetUserID(HttpContext.Request.Headers))!;
            var refreshToken = Request.Cookies["refresh_token"] ?? "-1";

            if (!_authRepos.IsTokenExist(user.ID, refreshToken))
            {
                return StatusCode(409, new
                {
                    status = "Токен не был найден"
                });
            }
            if (!_authRepos.IsTokenExpired(user.ID, refreshToken))
            {
                return StatusCode(401, new
                {
                    status = "Срок жизни токена истёк"
                });
            }

            var refresh_token = CreateRefreshToken();
            _authRepos.AddToken(new(user.ID, refresh_token.Value, refresh_token.Created, refresh_token.Expires));

            return StatusCode(201, new
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
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature));
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Создать refresh токен
        /// </summary>
        [NonAction]
        private RefreshTokenModel CreateRefreshToken()
        {
            var refresh_token = new RefreshTokenModel(Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)), DateTime.Now.AddDays(14), DateTime.Now);
            Response.Cookies.Append("refresh_token", refresh_token.Value, new CookieOptions { 
                Secure = true, 
                HttpOnly = true, 
                Expires = refresh_token.Expires });
            return refresh_token;
        }
    }
}