using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using server.Misc;
using database.context.Models;
using database.context.Repos;

namespace server.Controllers
{
    /// <summary>
    /// Взаимодействие с аккаунтом пользователя
    /// </summary>
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _db;

        public AccountController(IUserRepository db) => _db = db;

        /// <summary>
        /// Регистрация нового пользователя в системе
        /// </summary>
        /// <param name="currentUser">Информация о пользователе</param>
        [HttpPost]
        [Route("signUp")]
        public IActionResult SignUp(UserModel currentUser)
        {
            bool loginIsTaken = _db.GetByEmail(currentUser.Email) is not null;

            if (loginIsTaken)
            {
                return StatusCode(406);
            }
            else
            {
                _db.Add(currentUser);
                return Ok(new {
                    Token = CreateToken(currentUser),
                    StatusText = "Новый пользователь успешно зарегистрирован"
                });
            }
        }

        /// <summary>
        /// Авторизация пользователя в системе
        /// </summary>        
        /// <param name="currentUser">Информация о пользователе (логин и пароль)</param>
        [HttpPost]
        [Route("signIn")]
        public IActionResult SignIn(UserModel currentUser)
        {
            bool userExist = _db.GetByEmailAndPassword(currentUser.Email, currentUser.Password) is not null;

            if (userExist)
            {
                return Ok(new 
                { 
                    Token = CreateToken(currentUser),
                    StatusText = "Пользователь в БД найден"
                });
            }
            else
            {
                return NotFound(new
                {
                    StatusText = "Такого пользователя в БД не обнаружено"
                });
            }
        }

        /// <summary>
        /// Профиль пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpGet]
        [Route("profile/{id}")]
        public IActionResult Profile(int id)
        {
            UserModel? user = _db.GetByID(id);
            return Ok(new
            {
                User = user
            });
        }

        /// <summary>
        /// Создание токена для пользователя
        /// </summary>
        /// <param name="currentUser">Информация о пользователе</param>
        [NonAction]
        private static string CreateToken(UserModel currentUser)
        {
            List<Claim> claims = new() { new Claim(ClaimTypes.Name, currentUser.Email) };
            JwtSecurityToken jwt = new(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: new SigningCredentials(AuthOptions.GenerateToken(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}