using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.profiles.Models.Profiles.Languages
{
    /// <summary>
    /// Подробная информация о языке пользователя
    /// </summary>
    [Table("view_profile_languages")]
    public sealed class ProfileLanguageViewModel
    {
        /// <summary>
        /// Идентификатор связи
        /// </summary>
        [Key]
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Required]
        [Column("user_id")]
        public int UserID { get; set; }

        /// <summary>
        /// Идентификатор языка
        /// </summary>
        [Required]
        [Column("language_id")]
        public int LanguageID { get; set; }

        /// <summary>
        /// Наименование языка
        /// </summary>
        [Required]
        [Column("language_name")]
        public string LanguageName { get; set; }

        /// <summary>
        /// Дата добавления языка в профиль
        /// </summary>
        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Подробная информация о языке пользователя
        /// </summary>        
        /// <param name="id">Идентификатор связи</param>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="language_id">Идентификатор языка</param>
        /// <param name="language_name">Наименование языка</param>
        /// <param name="date">Дата добавления языка в профиль</param>
        public ProfileLanguageViewModel(int id, int user_id, int language_id, string language_name, DateTime date)
        {
            ID = id;
            UserID = user_id;
            LanguageID = language_id;
            LanguageName = language_name;
            Date = date;
        }

        /// <summary>
        /// Подробная информация о языке пользователя
        /// </summary>
        public ProfileLanguageViewModel() { }
    }
}