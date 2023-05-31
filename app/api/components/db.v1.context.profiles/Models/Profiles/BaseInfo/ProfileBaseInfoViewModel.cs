using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.profiles.Models.Profiles.BaseInfo
{
    /// <summary>
    /// Базовая информация о профиле пользователя с подробностями
    /// </summary>
    [Table("view_profile_base_info")]
    public sealed class ProfileBaseInfoViewModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Key]
        [Column("user_id")]
        public int UserID { get; set; }

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
        /// Идентификатор родного города пользователя
        /// </summary>
        [Column("city_id")]
        public int? CityID { get; set; }

        /// <summary>
        /// Родной город пользователя
        /// </summary>
        [Column("city_name")]
        public string? CityName { get; set; }

        /// <summary>
        /// Идентификатор семейного положения пользователя
        /// </summary>
        [Column("family_status_id")]
        public int? FamilyStatusID { get; set; }

        /// <summary>
        /// Статус отношений пользователя
        /// </summary>
        [Column("family_status_name")]
        public string? FamilyStatusName { get; set; }

        /// <summary>
        /// Базовая информация о профиле пользователя с подробностями
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="surname">Фамилия пользователя</param>
        /// <param name="name">Имя пользователя</param>
        /// <param name="patronymic">Отчество пользователя</param>
        /// <param name="avatar">Аватарка пользователя</param>
        /// <param name="birthdate">Дата рождения пользователя</param>
        /// <param name="city_id">Идентификатор родного города пользователя</param>
        /// <param name="city_name">Родной город пользователя</param>
        /// <param name="family_status_id">Идентификатор семейного положения пользователя</param>
        /// <param name="family_status_name">Статус отношений пользователя</param>

        public ProfileBaseInfoViewModel(int user_id, string surname, string name, string? patronymic, string? avatar, 
                                        string? status, DateTime? birthdate, int? city_id, string? city_name, 
                                        int? family_status_id, string? family_status_name)
        {
            UserID = user_id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Avatar = avatar;
            BirthDate = birthdate;
            Status = status;
            CityID = city_id;
            CityName = city_name;
            FamilyStatusID = family_status_id;
            FamilyStatusName = family_status_name;
        }

        /// <summary>
        /// Базовая информация о профиле пользователя с подробностями
        /// </summary>
        public ProfileBaseInfoViewModel() { }
    }
}