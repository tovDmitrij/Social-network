using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.main.Models
{
    /// <summary>
    /// Информация, необходимая для аутентификации пользователя в системе
    /// </summary>
    [Table("users")]
    public sealed class UserAuthModel
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

        public UserAuthModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public UserAuthModel(int id, string email, string password)
        {
            ID = id;
            Email = email;
            Password = password;
        }

        public UserAuthModel() { }
    }
}