using Microsoft.AspNetCore.Mvc;
using api.v1.service.auth.Misc;
using db.v1.context.auth.Repos;
namespace api.v1.service.auth.Controllers
{
    /// <summary>
    /// Аутентификация пользователя в системе
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class AuthController : ControllerBase
    {
        /// <summary>
        /// Взаимодействие с аккаунтами пользователей
        /// </summary>
        private readonly IAuthRepos _auth;

        public AuthController(IAuthRepos auth) =>  _auth = auth;

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
                    _auth.Add(email, password);

                    /*
                     * БРОКЕР СООБЩЕНИЙ В СЕРВИС ПРОФИЛЯ
                     */

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
                    var user = _auth.GetAccountInfo(email, password);

                    return StatusCode(200, new { status = "Аккаунт был успешно найден",
                        token = AuthOptions.CreateToken(user.ID.ToString(), user.RoleName) });

                case false:
                    return StatusCode(404, new { status = "Аккаунта с заданной почтой и паролем не существует" });
            }
        }
    }
}