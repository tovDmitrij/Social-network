using System.Security.Cryptography;
using System.Text;

namespace api.v1.service.main.Helpers
{
    public static class HashDataHelper
    {
        private const string SALT = "salt_secret_key";

        public static string HashPasswordSHA512(string email, string password)
        {
            var bytes = SHA512.HashData(Encoding.UTF8.GetBytes($"{SALT}{email}{password}"));
            var hashData = new StringBuilder();
            foreach (var @byte in bytes)
            {
                hashData.Append(@byte.ToString("x2"));
            }
            return hashData.ToString();
        }
    }
}