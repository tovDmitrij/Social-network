using Microsoft.EntityFrameworkCore;
using db.v1.context.dictionary.Models;
using db.v1.context.dictionary.Models.Places;
using db.v1.context.dictionary.Contexts.Interfaces;
namespace db.v1.context.dictionary
{
    /// <summary>
    /// Контекст БД словаря
    /// </summary>
    public sealed class DictionaryContext : DbContext, IFamilyStatusContext, ILanguageContext, ILifePositionContext, IPlaceContext
    {
        public DbSet<LanguageModel> TableLanguages { get; set; }

        public DbSet<LifePositionModel> ViewLifePositions { get; set; }

        public DbSet<PlaceModel> ViewPlaces { get; set; }

        public DbSet<CityModel> TableCities { get; set; }

        public DbSet<RegionModel> TableRegions { get; set; }

        public DbSet<CountryModel> TableCountries { get; set; }

        public DbSet<FamilyStatusModel> TableFamilyStatuses { get; set; }

        public DictionaryContext(DbContextOptions options) : base(options) { }
    }
}