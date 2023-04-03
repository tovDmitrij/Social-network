using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Data
{
    /// <summary>
    /// Информация о регионе
    /// </summary>
    [Table("regions")]
    public sealed class RegionModel
    {
        /// <summary>
        /// Идентификатор региона
        /// </summary>
        [Key]
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// Идентификатор страны, в которой находится регион
        /// </summary>
        [Required]
        [Column("country_id")]
        public int CountryID { get; set; }

        /// <summary>
        /// Наименование региона
        /// </summary>
        [Required]
        [Column("name")]
        public string Name { get; set; }

        public RegionModel(int id, int country_id, string name)
        {
            ID = id;
            CountryID = country_id;
            Name = name;
        }

        public RegionModel() { }
    }
}
