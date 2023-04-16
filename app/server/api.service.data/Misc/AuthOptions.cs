using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace api.service.data.Misc
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
        /// Создать токен с некоторым количеством claims
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="userTitle">Наименование роли</param>
        public static string CreateToken(string userID, string userTitle)
        {
            JwtSecurityToken token = new(
                issuer: ISSUER,
                audience: AUDIENCE,
                claims: new List<Claim> {
                    new(ClaimTypes.Name, userID),
                    new(ClaimTypes.Role, userTitle)
                },
                expires: DateTime.UtcNow.Add(TimeSpan.FromHours(24)),
                signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha512));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Получить список claims из токена
        /// </summary>
        /// <param name="token">Токен</param>
        public static IEnumerable<Claim> GetClaims(string token) => new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;

        /// <summary>
        /// Получть идентификатор пользователя из токена
        /// </summary>
        /// <param name="context">ХэТэПэПэ контекст</param>
        public static int GetUserID(HttpContext context)
        {
            try
            {
                string token = context.Request.Headers.Authorization.ToString().Split(' ')[1];
                IEnumerable<Claim> claims = GetClaims(token);
                int userID = Convert.ToInt32(claims.First(id => id.Type == ClaimTypes.Name).Value);
                return userID;
            }
            catch
            {
                return -1; 
            }
        }
    }
}