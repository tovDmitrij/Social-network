using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.profiles.Models.Profiles.Languages
{
    /// <summary>
    /// Информация о языке пользователя
    /// </summary>
    [Table("user_profile_languages")]
    public sealed class ProfileLanguageModel
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
        /// Дата добавления языка в профиль
        /// </summary>
        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Информация о языке пользователя
        /// </summary>
        /// <param name="id">Идентификатор связи</param>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="language_id">Идентификатор языка</param>
        /// <param name="date">Дата добавления языка в профиль</param>
        public ProfileLanguageModel(int id, int user_id, int language_id, DateTime date) : this(user_id, language_id, date) => ID = id;

        /// <summary>
        /// Информация о языке пользователя
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="language_id">Идентификатор языка</param>
        /// <param name="date">Дата добавления языка в профиль</param>
        public ProfileLanguageModel(int user_id, int language_id, DateTime date)
        {
            UserID = user_id;
            LanguageID = language_id;
            Date = date;
        }

        /// <summary>
        /// Информация о языке пользователя
        /// </summary>
        public ProfileLanguageModel() { }
    }
}