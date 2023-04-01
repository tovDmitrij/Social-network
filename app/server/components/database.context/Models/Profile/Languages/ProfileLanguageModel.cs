using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Profile.Languages
{
    /// <summary>
    /// Промежуточная модель, необходимая для добавления нового языка в профиль пользователя
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

        public ProfileLanguageModel(int id, int user_id, int language_id) : this(user_id, language_id)
        {
            ID = id;
        }

        public ProfileLanguageModel(int user_id, int language_id)
        {
            UserID = user_id;
            LanguageID = language_id;
        }

        public ProfileLanguageModel() { }
    }
}