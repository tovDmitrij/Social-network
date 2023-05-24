using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.profiles.Models.Dictionary.Places
{
    /// <summary>
    /// Информация о городе
    /// </summary>
    [Table("cities")]
    public sealed class CityModel
    {
        /// <summary>
        /// Идентификатор города
        /// </summary>
        [Key]
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// Идентификатор региона, в котором находится город
        /// </summary>
        [Required]
        [Column("region_id")]
        public int RegionID { get; set; }

        /// <summary>
        /// Наименование города
        /// </summary>
        [Required]
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Информация о городе
        /// </summary>
        /// <param name="id">Идентификатор города</param>
        /// <param name="region_id">Идентификатор региона, в котором находится город</param>
        /// <param name="name">Наименование города</param>
        public CityModel(int id, int region_id, string name)
        {
            ID = id;
            RegionID = region_id;
            Name = name;
        }

        /// <summary>
        /// Информация о городе
        /// </summary>
        public CityModel() { }
    }
}