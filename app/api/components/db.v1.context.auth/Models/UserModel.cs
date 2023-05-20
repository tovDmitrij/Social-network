using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.auth.Models
{
    /// <summary>
    /// Информация об аккаунте пользователя
    /// </summary>
    [Table("users")]
    public sealed class UserModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Key]
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// Почта пользователя
        /// </summary>
        [Required]
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required]
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// Дата регистрации пользователя
        /// </summary>
        [Required]
        [Column("registration_date")]
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Аккаунт пользователя
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        public UserModel(string email, string password)
        {
            Email = email;
            Password = password;
            RegistrationDate = DateTime.Now;
        }

        /// <summary>
        /// Аккаунт пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        public UserModel(int id, string email, string password, DateTime registration_date)
        {
            ID = id;
            Email = email;
            Password = password;
            RegistrationDate = registration_date;
        }

        /// <summary>
        /// Аккаунт пользователя
        /// </summary>
        public UserModel() { }
    }
}