using System.Security.Claims;
using Microsoft.AspNetCore.Http;
namespace helpers.jwt
{
    /// <summary>
    /// Взаимодействие с JWT-токеном в сервисе Auth
    /// </summary>
    public interface IAuthServiceToken
    {
        /// <summary>
        /// Получить идентификатор пользователя из access-токена
        /// </summary>
        /// <param name="header">Запрос к API</param>
        public int GetUserID(IHeaderDictionary header);

        /// <summary>
        /// Получить данные из access-токена
        /// </summary>
        /// <param name="token">Access-токен</param>
        public IEnumerable<Claim> GetClaims(string token);
    }
}