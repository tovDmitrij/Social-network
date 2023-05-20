using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.dictionary.Models.Places
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

        /// <summary>
        /// Информация о стране
        /// </summary>
        /// <param name="id">Идентификатор страны</param>
        /// <param name="name">Наименование страны</param>
        public CountryModel(int id, string name)
        {
            ID = id;
            Name = name;
        }

        /// <summary>
        /// Информация о стране
        /// </summary>
        public CountryModel() { }
    }
}