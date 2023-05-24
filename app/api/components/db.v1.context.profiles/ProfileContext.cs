using Microsoft.EntityFrameworkCore;
using db.v1.context.profiles.Models.Dictionary;
using db.v1.context.profiles.Models.Dictionary.Places;
using db.v1.context.profiles.Models.Profiles.BaseInfo;
using db.v1.context.profiles.Models.Profiles.Carrers;
using db.v1.context.profiles.Models.Profiles.Languages;
using db.v1.context.profiles.Models.Profiles.LifePositions;
using db.v1.context.profiles.Models.Profiles.MilitaryServices;
namespace db.v1.context.profiles
{
    /// <summary>
    /// Контекст БД с профилями пользователей
    /// </summary>
    public sealed class ProfileContext : DbContext
    {



        #region Профиль

        /// <summary>
        /// Таблица с базовой информацией о профилях пользователей
        /// </summary>
        public DbSet<ProfileBaseInfoModel> TableProfileBaseInfo { get; set; }
        /// <summary>
        /// Представление с базовой информацией о профилях пользователей
        /// </summary>
        public DbSet<ProfileBaseInfoViewModel> ViewProfileBaseInfo { get; set; }


        /// <summary>
        /// Таблица с выбранными пользователями языками в профиле
        /// </summary>
        public DbSet<ProfileLanguageModel> TableProfileLanguages { get; set; }
        /// <summary>
        /// Представление с подробной информацией о выбранных пользователями языками в профиле
        /// </summary>
        public DbSet<ProfileLanguageViewModel> ViewProfileLanguages { get; set; }


        /// <summary>
        /// Таблица с жизненными позициями пользователей
        /// </summary>
        public DbSet<ProfileLifePositionModel> TableProfileLifePositions { get; set; }
        /// <summary>
        /// Представление с подробной информацией о жизненных позициях пользователей
        /// </summary>
        public DbSet<ProfileLifePositionViewModel> ViewProfileLifePositions { get; set; }


        /// <summary>
        /// Таблица с карьерами пользователей
        /// </summary>
        public DbSet<ProfileCarrerModel> TableProfileCarrer { get; set; }
        /// <summary>
        /// Представление с подробной информацией о карьерах пользователей
        /// </summary>
        public DbSet<ProfileCarrerViewModel> ViewProfileCarrer { get; set; }


        /// <summary>
        /// Таблица с военными службами пользователей
        /// </summary>
        public DbSet<ProfileMilitaryServiceModel> TableProfileMilitaryService { get; set; }
        /// <summary>
        /// Представление с подробной информацией о военных службах пользователей
        /// </summary>
        public DbSet<ProfileMilitaryServiceViewModel> ViewProfileMilitaryService { get; set; }

        #endregion



        #region Справочник

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

        #endregion



        public ProfileContext(DbContextOptions options) : base(options) { }
    }
}