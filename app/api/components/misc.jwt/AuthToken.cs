using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
namespace misc.jwt
{
    /// <summary>
    /// Взаимодействие с JWT-токеном
    /// </summary>
    public static class AuthToken
    {

        /// <summary>
        /// Получить идентификатор пользователя из access-токена
        /// </summary>
        /// <param name="header">Запрос к API</param>
        public static int GetUserID(IHeaderDictionary header)
        {
            try
            {
                string token = header.Authorization.ToString().Split(' ')[1];
                IEnumerable<Claim> claims = GetClaims(token);
                int userID = Convert.ToInt32(claims.First(id => id.Type == ClaimTypes.Name).Value);
                return userID;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Получить данные из access-токена
        /// </summary>
        /// <param name="token">Access-токен</param>
        public static IEnumerable<Claim> GetClaims(string token) => new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
    }
}