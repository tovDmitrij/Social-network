using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.dictionary.Models
{
    /// <summary>
    /// Информация о языке
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

        /// <summary>
        /// Информация о языке
        /// </summary>        
        /// <param name="id">Идентификатор языка</param>
        /// <param name="name">Наименование языка</param>
        public LanguageModel(int id, string name)
        {
            ID = id;
            Name = name;
        }

        /// <summary>
        /// Информация о языке
        /// </summary>
        public LanguageModel() { }
    }
}