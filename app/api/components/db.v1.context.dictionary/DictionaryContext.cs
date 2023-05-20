using Microsoft.EntityFrameworkCore;
using db.v1.context.dictionary.Models;
using db.v1.context.dictionary.Models.Places;
namespace db.v1.context.dictionary
{
    /// <summary>
    /// Контекст БД словаря
    /// </summary>
    public sealed class DictionaryContext : DbContext
    {
        /// <summary>
        /// Таблица с информацией обо всех языках
        /// </summary>
        public DbSet<LanguageModel> TableLanguages { get; set; }

        /// <summary>
        /// Представление с информацией обо всех жизненных позициях
        /// </summary>
        public DbSet<LifePositionModel> ViewLifePositions { get; set; }

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

        /// <summary>
        /// Таблица с информацией обо всех семейных положениях
        /// </summary>
        public DbSet<FamilyStatusModel> TableFamilyStatuses { get; set; }

        public DictionaryContext(DbContextOptions options) : base(options) { }
    }
}