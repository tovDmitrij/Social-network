using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.main.Models.Profile.BaseInfo
{
    /// <summary>
    /// Модель с базовая информацией о пользователе
    /// </summary>
    [Keyless]
    [Table("view_user_base_info")]
    public sealed class ProfileBaseInfoViewModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Required]
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// Идентификатор роли пользователя в системе
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
        public byte[]? Avatar { get; set; }

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
        /// Город проживания пользователя
        /// </summary>
        [Column("city")]
        public string? City { get; set; }

        /// <summary>
        /// Статус отношений пользователя
        /// </summary>
        [Column("family_status")]
        public string? FamilyStatus { get; set; }

        public ProfileBaseInfoViewModel(int id, DateTime registration_date, string role_title, string surname, string name, string? patronymic, byte[] avatar, DateTime birthdate, string city, string family_status)
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

        public ProfileBaseInfoViewModel() { }
    }
}