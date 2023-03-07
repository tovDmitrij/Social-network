using System.Security.Cryptography;
using System.Text;

namespace misc.security
{
    /// <summary>
    /// Различные методы шифрования и хеширования данных
    /// </summary>
    public static class Security
    {
        /// <summary>
        /// SHA512 хеширование
        /// </summary>
        /// <param name="data">Данные</param>
        /// <returns>Захешированные данные</returns>
        public static string ToSHA512(string data)
        {
            byte[] bytes = SHA512.HashData(Encoding.UTF8.GetBytes(data));
            var hashData = new StringBuilder();
            foreach (byte currentByte in bytes)
            {
                hashData.Append(currentByte.ToString("x2"));
            }
            return hashData.ToString();
        }

        /// <summary>
        /// Шифрование данных
        /// </summary>
        /// <param name="data">Данные</param>
        /// <returns>Зашифрованные данные</returns>
        public static string EncodeData(string data) =>
            Convert.ToBase64String(Encoding.UTF8.GetBytes(data));

        /// <summary>
        /// Дешифрование данных
        /// </summary>
        /// <param name="data">Данные</param>
        /// <returns>Дешифрованные данные</returns>
        public static string DecodeData(string data) =>
            Encoding.UTF8.GetString(Convert.FromBase64String(data));
    }
}