using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Profile.Languages
{
    /// <summary>
    /// Информация о выбранном пользователем в профиле языке
    /// </summary>
    [Keyless]
    [Table("view_profile_languages")]
    public sealed class ProfileLanguageInfoModel
    {
        /// <summary>
        /// Идентификатор языка
        /// </summary>
        [Required]
        [Column("id")]
        public int LanguageID { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Required]
        [Column("user_id")]
        public int UserID { get; set; }

        /// <summary>
        /// Наименование языка
        /// </summary>
        [Required]
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Дата добавления языка в профиль
        /// </summary>
        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        public ProfileLanguageInfoModel(int id, int user_id, string name, DateTime date)
        {
            LanguageID = id;
            UserID = user_id;
            Name = name;
            Date = date;
        }

        public ProfileLanguageInfoModel() { }
    }
}