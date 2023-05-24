using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.profiles.Models.Dictionary.Places
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

        /// <summary>
        /// Информация о регионе
        /// </summary>
        /// <param name="id">Идентификатор региона</param>
        /// <param name="country_id">Идентификатор страны, в которой находится регион</param>
        /// <param name="name">Наименование региона</param>
        public RegionModel(int id, int country_id, string name)
        {
            ID = id;
            CountryID = country_id;
            Name = name;
        }

        /// <summary>
        /// Информация о регионе
        /// </summary>
        public RegionModel() { }
    }
}
