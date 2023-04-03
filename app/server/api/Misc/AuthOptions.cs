using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace api.Misc
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

        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new(Encoding.UTF8.GetBytes(KEY));
    }
}