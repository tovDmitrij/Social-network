using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace server.Misc
{
    /// <summary>
    /// Настройки генерации токена JWT
    /// </summary>
    internal sealed class AuthOptions
    {
        /// <summary>
        /// Издатель токена
        /// </summary>
        public const string ISSUER = "Server";

        /// <summary>
        /// Потребитель токена
        /// </summary>
        public const string AUDIENCE = "Client";

        /// <summary>
        /// Секретный ключ (сигнатура)
        /// </summary>
        private const string KEY = "mysupersecret_secretkey!123";

        /// <summary>
        /// Генерация токена по секретному ключу
        /// </summary>
        public static SymmetricSecurityKey GenerateToken() =>
            new(Encoding.UTF8.GetBytes(KEY));
    }
}