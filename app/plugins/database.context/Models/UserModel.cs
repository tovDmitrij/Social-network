using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models
{
    /// <summary>
    /// Пользователь социальной сети
    /// </summary>
    [Table("users")]
    public class UserModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// Дата регистрации
        /// </summary>
        [Column("registration_date")]
        public DateTime RegistrationDate { get; set; }

        public UserModel(int id, string email, string password, DateTime registration_date)
        {
            ID = id;
            Email = email;
            Password = password;
            RegistrationDate = registration_date;
        }

        public UserModel() { }
    }
}
