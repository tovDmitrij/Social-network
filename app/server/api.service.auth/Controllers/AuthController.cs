using Microsoft.AspNetCore.Mvc;
using api.service.auth.Misc;
using database.context.main.Repos.User;
using database.context.main.Repos.Profile;
namespace api.service.auth.Controllers
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
        [HttpPost("SignIn/email={email}&password={password}")]
        public IActionResult SignIn(string email, string password)
        {
            switch (_auth.IsAccountExist(email, password))
            {
                case true:
                    var user = _profile.GetProfileBaseInfo(_auth.GetAccountInfo(email, password).ID);
                    return StatusCode(200, new { status = "Аккаунт был успешно найден",
                        token = AuthOptions.CreateToken(user.ID.ToString(), user.RoleTitle) });

                case false:
                    return StatusCode(404, new { status = "Аккаунта с заданной почтой и паролем не существует" });
            }
        }
    }
}