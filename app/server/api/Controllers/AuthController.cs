using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using api.Misc;
using database.context.Repos.User;
using database.context.Models.Auth;
using database.context.Repos.Profile;
using database.context.Models.Profile;
namespace api.Controllers
{
    /// <summary>
    /// Аутентификация пользователя в системе
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepos _auth;

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
        [HttpPost("SignUp")]
        public IActionResult SignUp(string email, string password, string surname, string name, string? patronymic)
        {
            bool loginIsTaken = _auth.GetByEmail(email) is not null;

            switch (loginIsTaken)
            {
                case true:
                    return StatusCode(406, 
                        new 
                        {
                            status = "Почта уже занята другим пользователем"
                        });
                case false:
                    try
                    {
                        _auth.Add(email, password, surname, name, patronymic);
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(406, 
                            new 
                            {
                                status = ex.Message
                            });
                    }
                    return StatusCode(200,
                        new 
                        {
                            status = "Пользователь успешно зарегистрирован"
                        });
            }
        }

        /// <summary>
        /// Авторизация пользователя в системе
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользоватея</param>
        [HttpPost("SignIn")]
        public IActionResult SignIn(string email, string password)
        {
            UserAuthModel? userExist = _auth.GetByEmailAndPassword(email, password);

            switch (userExist is null)
            {
                case true:
                    return StatusCode(404, 
                        new 
                        { 
                            status = "Пользователя с такой почтой и паролем не существует" 
                        });
                case false:
                    UserBaseInfoModel user = _profile.GetProfileBaseInfo(userExist.ID);

                    JwtSecurityToken token = new(
                            issuer: AuthOptions.ISSUER,
                            audience: AuthOptions.AUDIENCE,
                            claims: new List<Claim> { 
                                new(ClaimTypes.Role, user.RoleTitle),
                                new(ClaimTypes.Name, email) 
                            },
                            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha512));
                    
                    return StatusCode(200, 
                        new 
                        { 
                            status = "Пользователь успешно найден", 
                            id = user.ID,
                            token = new JwtSecurityTokenHandler().WriteToken(token)
                        });
            }
        }
    }
}