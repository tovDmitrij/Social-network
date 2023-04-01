using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Profile.Languages
{
    /// <summary>
    /// Информация о выбранном пользователем в профиле языке
    /// </summary>
    [Table("view_profile_languages")]
    public sealed class ProfileLanguageModel
    {
        /// <summary>
        /// Идентификатор языка
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

        public ProfileLanguageModel(int id, int user_id, string name, DateTime date)
        {
            ID = id;
            UserID = user_id;
            Name = name;
            Date = date;
        }

        public ProfileLanguageModel() { }
    }
}