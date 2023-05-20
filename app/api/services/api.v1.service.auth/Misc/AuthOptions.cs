using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace api.v1.service.auth.Misc
{
    /// <summary>
    /// Настройки генерации токена
    /// </summary>
    [NonController]
    internal sealed class AuthOptions
    {
        /// <summary>
        /// Издатель токена
        /// </summary>
        public const string ISSUER = "OnCallService";

        /// <summary>
        /// Потребитель токена
        /// </summary>
        public const string AUDIENCE = "ReactClient";

        /// <summary>
        /// Ключ для шифрования токена
        /// </summary>
        private const string KEY = "Seth_MacFarlane-My_Way";

        public static SymmetricSecurityKey GetSymmetricSecurityKey() => new(Encoding.UTF8.GetBytes(KEY));

        /// <summary>
        /// Создать JWT-токен
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="role">Наименование роли</param>
        public static string CreateToken(string id, string role)
        {
            JwtSecurityToken token = new(
                issuer: ISSUER,
                audience: AUDIENCE,
                claims: new List<Claim> {
                    new(ClaimTypes.Name, id),
                    new(ClaimTypes.Role, role)
                },
                expires: DateTime.UtcNow.Add(TimeSpan.FromHours(24)),
                signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha512));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}