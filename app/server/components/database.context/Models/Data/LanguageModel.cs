using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.main.Models.Misc
{
    /// <summary>
    /// Модель с информацией об языке, присутствующем на платформе
    /// </summary>
    [Table("languages")]
    public sealed class LanguageModel
    {
        /// <summary>
        /// Идентификатор языка
        /// </summary>
        [Key]
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// Наименование языка
        /// </summary>
        [Required]
        [Column("name")]
        public string Name { get; set; }

        public LanguageModel(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public LanguageModel() { }
    }
}