using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.auth.Models
{
    /// <summary>
    /// Подробная информация об аккаунте пользователя
    /// </summary>
    [Table("view_users")]
    public sealed class UserViewModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Key]
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// Идентификатор роли пользователя в системе
        /// </summary>
        [Required]
        [Column("role_id")]
        public int RoleID { get; set; }

        /// <summary>
        /// Наименование роли пользователя в системе
        /// </summary>
        [Required]
        [Column("role_name")]
        public string RoleName { get; set; }

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
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="role_id"></param>
        /// <param name="role_name"></param>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="registration_date"></param>
        public UserViewModel(int id, int role_id, string role_name, string email, string password, DateTime registration_date)
        {
            ID = id;
            RoleID = role_id;
            RoleName = role_name;
            Email = email;
            Password = password;
            RegistrationDate = registration_date;
        }

        /// <summary>
        /// Аккаунт пользователя
        /// </summary>
        public UserViewModel() { }
    }
}