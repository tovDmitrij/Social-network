using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Auth
{
    /// <summary>
    /// Информация, необходимая для аутентификации пользователя в системе
    /// </summary>
    [Table("user_profile_main_info")]
    public class ProfileAuthModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Key]
        [Column("user_id")]
        public int ID { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        [Required]
        [Column("surname")]
        public string Surname { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required]
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Отчество пользователя
        /// </summary>
        [Column("patronymic")]
        public string Patronymic { get; set; }

        public ProfileAuthModel(int user_id, string surname, string name, string patronymic) : this(user_id, surname, name)
        {
            Patronymic = patronymic;
        }

        public ProfileAuthModel(int user_id, string surname, string name)
        {
            ID = user_id;
            Surname = surname;
            Name = name;
        }

        public ProfileAuthModel() { }
    }
}