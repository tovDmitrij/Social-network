using System.Security.Cryptography;
using System.Text;
namespace misc.security
{
    /// <summary>
    /// Различные методы, обеспечивающие безопасность данных
    /// </summary>
    public static class Security
    {
        private const string SALT = "salt_secret_key";

        /// <summary>
        /// Хешировать пароль с помощью алгоритма SHA512
        /// </summary>
        /// <param name="email">Почта, необходимая для генерации динамической соли</param>
        /// <param name="password">Непосредственно пароль</param>
        public static string HashPassword(string email, string password)
        {
            byte[] bytes = SHA512.HashData(Encoding.UTF8.GetBytes($"{SALT}{email}{password}"));
            var hashData = new StringBuilder();
            foreach (byte @byte in bytes)
            {
                hashData.Append(@byte.ToString("x2"));
            }
            return hashData.ToString();
        }
    }
}