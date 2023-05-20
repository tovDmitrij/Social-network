using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.dictionary.Models.Places
{
    /// <summary>
    /// Информация о месте проживания
    /// </summary>
    [Keyless]
    [Table("view_places")]
    public sealed class PlaceModel
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

        /// <summary>
        /// Информация о месте проживания
        /// </summary>
        /// <param name="city_id">Идентификатор города</param>
        /// <param name="city_name">Наименование города</param>
        /// <param name="region_id">Идентификатор региона</param>
        /// <param name="region_name">Наименование региона</param>
        /// <param name="country_id">Идентификатор страны</param>
        /// <param name="country_name">Наименование страны</param>
        public PlaceModel(int city_id, string city_name, int region_id, string region_name, int country_id, string country_name)
        {
            CityID = city_id;
            CityName = city_name;
            RegionID = region_id;
            RegionName = region_name;
            CountryID = country_id;
            CountryName = country_name;
        }

        /// <summary>
        /// Информация о месте проживания
        /// </summary>
        public PlaceModel() { }
    }
}