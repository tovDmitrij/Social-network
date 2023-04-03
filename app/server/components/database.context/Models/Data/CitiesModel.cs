using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Data
{
    /// <summary>
    /// Полная информация о городах, хранящихся в системе
    /// </summary>
    [Keyless]
    [Table("view_cities")]
    public sealed class CitiesModel
    {
        /// <summary>
        /// Идентификатор города
        /// </summary>
        [Required]
        [Column("city_id")]
        public int CityID { get; set; }

        /// <summary>
        /// Наименование города
        /// </summary>
        [Required]
        [Column("city_name")]
        public string CityName { get; set; }

        /// <summary>
        /// Идентификатор региона
        /// </summary>
        [Required]
        [Column("region_id")]
        public int RegionID { get; set; }

        /// <summary>
        /// Наименование региона
        /// </summary>
        [Required]
        [Column("region_name")]
        public string RegionName { get; set; }

        /// <summary>
        /// Идентификатор страны
        /// </summary>
        [Required]
        [Column("country_id")]
        public int CountryID { get; set; }

        /// <summary>
        /// Наименование страны
        /// </summary>
        [Required]
        [Column("country_name")]
        public string CountryName { get; set; }

        public CitiesModel(int city_id, string city_name, int region_id, string region_name, int country_id, string country_name)
        {
            CityID = city_id;
            CityName = city_name;
            RegionID = region_id;
            RegionName = region_name;
            CountryID = country_id;
            CountryName = country_name;
        }

        public CitiesModel() { }
    }
}