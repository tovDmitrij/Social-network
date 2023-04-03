using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Data
{
    /// <summary>
    /// Информация о стране
    /// </summary>
    [Table("countries")]
    public sealed class CountryModel
    {
        /// <summary>
        /// Идентификатор страны
        /// </summary>
        [Key]
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// Наименование страны
        /// </summary>
        [Required]
        [Column("name")]
        public string Name { get; set; }

        public CountryModel(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public CountryModel() { }
    }
}