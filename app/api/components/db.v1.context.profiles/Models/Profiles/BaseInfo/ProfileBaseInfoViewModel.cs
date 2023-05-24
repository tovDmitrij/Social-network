using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.profiles.Models.Profiles.BaseInfo
{
    /// <summary>
    /// Базовая информация о профиле пользователя с подробностями
    /// </summary>
    [Keyless]
    [Table("view_profile_base_info")]
    public sealed class ProfileBaseInfoViewModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Required]
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// Роль пользователя в системе
        /// </summary>
        [Required]
        [Column("role_title")]
        public string RoleTitle { get; set; }

        /// <summary>
        /// Дата регистрации пользователя
        /// </summary>
        [Required]
        [Column("registration_date")]
        public DateTime RegistrationDate { get; set; }

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
        /// Родной город пользователя
        /// </summary>
        [Column("city")]
        public string? City { get; set; }

        /// <summary>
        /// Статус отношений пользователя
        /// </summary>
        [Column("family_status")]
        public string? FamilyStatus { get; set; }

        /// <summary>
        /// Базовая информация о профиле пользователя с подробностями
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="registration_date">Дата регистрации пользователя</param>
        /// <param name="role_title">Роль пользователя в системе</param>
        /// <param name="surname">Фамилия пользователя</param>
        /// <param name="name">Имя пользователя</param>
        /// <param name="patronymic">Отчество пользователя</param>
        /// <param name="avatar">Аватарка пользователя</param>
        /// <param name="birthdate">Дата рождения пользователя</param>
        /// <param name="city">Родной город пользователя</param>
        /// <param name="family_status">Статус отношений пользователя</param>
        public ProfileBaseInfoViewModel(int id, DateTime registration_date, string role_title, string surname, string name, string? patronymic, string? avatar, DateTime birthdate, string city, string family_status)
        {
            ID = id;
            RoleTitle = role_title;
            RegistrationDate = registration_date;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Avatar = avatar;
            BirthDate = birthdate;
            City = city;
            FamilyStatus = family_status;
        }

        /// <summary>
        /// Базовая информация о профиле пользователя с подробностями
        /// </summary>
        public ProfileBaseInfoViewModel() { }
    }
}