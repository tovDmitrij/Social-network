using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using api.Misc;
using database.context.main.Repos.User;
using database.context.main.Repos.Profile;
using database.context.main.Models.Profile.BaseInfo;
namespace api.Controllers
{
    /// <summary>
    /// Аутентификация пользователя в системе
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public sealed class AuthController : ControllerBase
    {
        /// <summary>
        /// Взаимодействие с аккаунтами пользователей
        /// </summary>
        private readonly IAuthRepos _auth;

        /// <summary>
        /// Взаимодействие с профилями пользователей
        /// </summary>
        private readonly IProfileRepos _profile;

        public AuthController(IAuthRepos auth, IProfileRepos profile)
        {
            _auth = auth;
            _profile = profile;
        }

        /// <summary>
        /// Регистрация нового пользователя в системе
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользоватея</param>
        /// <param name="surname">Фамилия пользователя</param>
        /// <param name="name">Имя пользователя</param>
        /// <param name="patronymic">Отчество пользователя</param>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 406)]
        [HttpPost("SignUp/email={email}&password={password}&surname={surname}&name={name}&patronymic={patronymic}")]
        public IActionResult SignUp(string email, string password, string surname, string name, string? patronymic)
        {
            switch (_auth.IsEmailBusy(email))
            {
                case true:
                    return StatusCode(406, new { status = "Почта уже занята другим пользователем" });

                case false:
                    _auth.Add(email, password, surname, name, patronymic);
                    return StatusCode(200, new { status = "Новый аккаунт был успешно зарегистрирован" });
            }
        }

        /// <summary>
        /// Авторизация пользователя в системе
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользоватея</param>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpPost("SignIn/email={email}&password={password}")]
        public IActionResult SignIn(string email, string password)
        {
            switch (_auth.IsAccountExist(email, password))
            {
                case true:
                    ProfileBaseInfoViewModel user = _profile.GetProfileBaseInfo(_auth.GetAccountInfo(email, password).ID);

                    JwtSecurityToken token = new(
                            issuer: AuthOptions.ISSUER,
                            audience: AuthOptions.AUDIENCE,
                            claims: new List<Claim> {
                                new(ClaimTypes.Role, user.RoleTitle),
                                new(ClaimTypes.Name, email)
                            },
                            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha512));
                    return StatusCode(200, new { status = "Аккаунт был успешно найден", id = user.ID, token = new JwtSecurityTokenHandler().WriteToken(token) });

                case false:
                    return StatusCode(404, new { status = "Аккаунта с заданной почтой и паролем не существует" });
            }
        }
    }
}