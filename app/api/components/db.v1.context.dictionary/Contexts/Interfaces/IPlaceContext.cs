using Microsoft.EntityFrameworkCore;
using db.v1.context.dictionary.Models.Places;
namespace db.v1.context.dictionary.Contexts.Interfaces
{
    /// <summary>
    /// Контекст БД с таблицами городов, регионов и стран мира
    /// </summary>
    internal interface IPlaceContext
    {
        /// <summary>
        /// Представление с информацией обо всех местах проживания
        /// </summary>
        public DbSet<PlaceModel> ViewPlaces { get; set; }

        /// <summary>
        /// Таблица с информацией обо всех городах
        /// </summary>
        public DbSet<CityModel> TableCities { get; set; }

        /// <summary>
        /// Таблица с информацией обо всех регионах
        /// </summary>
        public DbSet<RegionModel> TableRegions { get; set; }

        /// <summary>
        /// Таблица с информацией обо всех странах
        /// </summary>
        public DbSet<CountryModel> TableCountries { get; set; }
    }
}