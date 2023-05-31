using Microsoft.EntityFrameworkCore;
using db.v1.context.profiles.Models.Dictionary;
using db.v1.context.profiles.Models.Dictionary.Places;
using db.v1.context.profiles.Models.Profiles.BaseInfo;
using db.v1.context.profiles.Models.Profiles.Carrers;
using db.v1.context.profiles.Models.Profiles.Languages;
using db.v1.context.profiles.Models.Profiles.LifePositions;
using db.v1.context.profiles.Models.Profiles.MilitaryServices;
using db.v1.context.profiles.Contexts.Interfaces;
namespace db.v1.context.profiles.Contexts
{
    /// <summary>
    /// Контекст БД с профилями пользователей
    /// </summary>
    public sealed class ProfileContext : DbContext, IFamilyStatusContext, ILanguageContext, ILifePositionContext, IPlaceContext, IProfileContext
    {



        #region Профиль

        public DbSet<ProfileBaseInfoModel> TableProfileBaseInfo { get; set; }

        public DbSet<ProfileBaseInfoViewModel> ViewProfileBaseInfo { get; set; }

        public DbSet<ProfileLanguageModel> TableProfileLanguages { get; set; }

        public DbSet<ProfileLanguageViewModel> ViewProfileLanguages { get; set; }

        public DbSet<ProfileLifePositionModel> TableProfileLifePositions { get; set; }

        public DbSet<ProfileLifePositionViewModel> ViewProfileLifePositions { get; set; }

        public DbSet<ProfileCarrerModel> TableProfileCarrer { get; set; }

        public DbSet<ProfileCarrerViewModel> ViewProfileCarrer { get; set; }

        public DbSet<ProfileMilitaryServiceModel> TableProfileMilitaryService { get; set; }

        public DbSet<ProfileMilitaryServiceViewModel> ViewProfileMilitaryService { get; set; }

        #endregion



        #region Справочник

        public DbSet<LanguageModel> TableLanguages { get; set; }

        public DbSet<LifePositionModel> ViewLifePositions { get; set; }

        public DbSet<PlaceModel> ViewPlaces { get; set; }

        public DbSet<CityModel> TableCities { get; set; }

        public DbSet<RegionModel> TableRegions { get; set; }

        public DbSet<CountryModel> TableCountries { get; set; }

        public DbSet<FamilyStatusModel> TableFamilyStatuses { get; set; }

        #endregion



        public ProfileContext(DbContextOptions options) : base(options) { }
    }
}