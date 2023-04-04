using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.main.Models.Data
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

        public CityModel(int id, int region_id, string name)
        {
            ID = id;
            RegionID = region_id;
            Name = name;
        }

        public CityModel() { }
    }
}