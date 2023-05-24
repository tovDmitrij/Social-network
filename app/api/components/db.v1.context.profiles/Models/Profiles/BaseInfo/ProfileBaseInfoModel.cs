using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace db.v1.context.profiles.Models.Profiles.BaseInfo
{
    /// <summary>
    /// Базовая информация о профиле пользователя
    /// </summary>
    [Table("user_profile_main_info")]
    public sealed class ProfileBaseInfoModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Key]
        [Column("user_id")]
        public int UserID { get; set; }

        /// <summary>
        /// Идентификатор семейного положения пользователя
        /// </summary>
        [Column("family_status_id")]
        public int? FamilyStatusID { get; set; }

        /// <summary>
        /// Идентификатор родного города пользователя
        /// </summary>
        [Column("city_id")]
        public int? CityID { get; set; }

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
        public string? Patronymic { get; set; }

        /// <summary>
        /// Аватарка пользователя
        /// </summary>
        [Column("avatar")]
        public string? Avatar { get; set; }

        /// <summary>
        /// Статус пользователя в его профиле
        /// </summary>
        [Column("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Дата рождения пользователя
        /// </summary>
        [Column("birthdate")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Базовая информация о профиле пользователя
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="family_status_id">Идентификатор семейного положения пользователя</param>
        /// <param name="city_id">Идентификатор родного города пользователя</param>
        /// <param name="surname">Фамилия пользователя</param>
        /// <param name="name">Имя пользователя</param>
        /// <param name="patronymic">Отчество пользователя</param>
        /// <param name="avatar">Аватарка пользователя</param>
        /// <param name="status">Статус пользователя в его профиле</param>
        /// <param name="birthdate">Дата рождения пользователя</param>
        public ProfileBaseInfoModel(int user_id, int? family_status_id, int? city_id, string surname, string name, string? patronymic, string? avatar, string? status, DateTime? birthdate)
        {
            UserID = user_id;
            FamilyStatusID = family_status_id;
            CityID = city_id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Avatar = avatar;
            Status = status;
            BirthDate = birthdate;
        }

        /// <summary>
        /// Базовая информация о профиле пользователя
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="surname">Фамилия пользователя</param>
        /// <param name="name">Имя пользователя</param>
        /// <param name="patronymic">Отчество пользователя</param>
        public ProfileBaseInfoModel(int user_id, string surname, string name, string patronymic)
        {
            UserID = user_id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
        }

        /// <summary>
        /// Базовая информация о профиле пользователя
        /// </summary>
        public ProfileBaseInfoModel() { }
    }
}