﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using api.Misc;
using database.context.Repos.User;
using database.context.Repos.Profile;
using database.context.Models.Profile;
namespace api.Controllers
{
    /// <summary>
    /// Аутентификация пользователя в системе
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public sealed class AuthController : BaseController
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
        [HttpPost("SignUp")]
        public IActionResult SignUp(string email, string password, string surname, string name, string? patronymic)
        {
            switch (_auth.IsEmailBusy(email))
            {
                case true:
                    return EmailIsNotAcceptable;

                case false:
                    _auth.Add(email, password, surname, name, patronymic);
                    return SignUpOk;
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
            switch (_auth.IsAccountExist(email, password))
            {
                case true:
                    ProfileBaseInfoModel user = _profile.GetProfileBaseInfo(_auth.GetAccountInfo(email, password).ID);

                    JwtSecurityToken token = new(
                            issuer: AuthOptions.ISSUER,
                            audience: AuthOptions.AUDIENCE,
                            claims: new List<Claim> {
                                new(ClaimTypes.Role, user.RoleTitle),
                                new(ClaimTypes.Name, email)
                            },
                            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha512));

                    return SignInOk(user.ID, new JwtSecurityTokenHandler().WriteToken(token));

                case false:
                    return SignInNotFound;
            }
        }
    }
}