using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace api.Misc
{
    /// <summary>
    /// Настройки генерации токена
    /// </summary>
    internal sealed class AuthOptions
    {
        /// <summary>
        /// Издатель токена
        /// </summary>
        public const string ISSUER = "MyAuthServer";

        /// <summary>
        /// Потребитель токена
        /// </summary>
        public const string AUDIENCE = "MyAuthClient";

        /// <summary>
        /// Ключ для шифрования токена
        /// </summary>
        private const string KEY = "mysupersecret_secretkey!123";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new(Encoding.UTF8.GetBytes(KEY));
    }
}