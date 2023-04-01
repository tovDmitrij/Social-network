using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Profile.Languages
{
    /// <summary>
    /// Информация, необходимая для добавления нового языка в профиль пользователя
    /// </summary>
    [Table("user_profile_languages")]
    public sealed class LanguageModel
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("user_id")]
        public int UserID { get; set; }

        [Required]
        [Column("language_id")]
        public int LanguageID { get; set; }

        public LanguageModel(int user_id, int language_id)
        {
            UserID = user_id;
            LanguageID = language_id;
        }

        public LanguageModel() { }
    }
}