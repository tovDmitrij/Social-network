using Microsoft.EntityFrameworkCore;
using database.context.Models.Misc;
using database.context.Models.Auth;
using database.context.Models.Data;
using database.context.Models.Profile;
using database.context.Models.Profile.Languages;
using database.context.Models.Profile.LifePositions;
namespace database.context.Contexts
{
    /// <summary>
    /// Основной контекст базы данных социальной сети
    /// </summary>
    public sealed class MainContext : DbContext
    {



        #region Аккаунт пользователя

        /// <summary>
        /// Таблица с аккаунтами пользователей
        /// </summary>
        public DbSet<UserAuthModel> TableUsers { get; set; }

        #endregion



        #region Профиль пользователя

        /// <summary>
        /// Таблица с базовой информацией об аккаунтах пользователей
        /// </summary>
        public DbSet<ProfileAuthModel> TableProfileBaseInfo { get; set; }

        /// <summary>
        /// Представление с базовой информацией о профилях пользователей
        /// </summary>
        public DbSet<ProfileBaseInfoModel> ViewProfileBaseInfo { get; set; }

        /// <summary>
        /// Таблица с выбранными пользователями языками в профиле
        /// </summary>
        public DbSet<ProfileLanguageModel> TableProfileLanguages { get; set; }

        /// <summary>
        /// Представление с подробной информацией о выбранных пользователями языками в профиле
        /// </summary>
        public DbSet<ProfileLanguageInfoModel> ViewProfileLanguages { get; set; }

        /// <summary>
        /// Таблица с жизненными позициями пользователей
        /// </summary>
        public DbSet<ProfileLifePositionModel> TableProfileLifePositions { get; set; }

        /// <summary>
        /// Представление с подробной информацией о жизненных позициях пользователей
        /// </summary>
        public DbSet<ProfileLifePositionsInfoModel> ViewProfileLifePositions { get; set; }

        #endregion



        #region Прочее

        /// <summary>
        /// Таблица с информацией обо всех языках на платформе
        /// </summary>
        public DbSet<LanguageModel> TableLanguages { get; set; }

        /// <summary>
        /// Представление с информацией обо все жизненных позициях на платформе
        /// </summary>
        public DbSet<LifePositionModel> ViewLifePositions { get; set; }

        /// <summary>
        /// Представление с информацией обо всех местах проживания на платформе
        /// </summary>
        public DbSet<PlaceOfLivingModel> ViewPlaceOfLiving { get; set; }

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
        /// Таблица с информацией обо всех семейных положениях на платформе
        /// </summary>
        public DbSet<FamilyStatusModel> TableFamilyStatuses { get; set; }

        #endregion



        public MainContext(DbContextOptions options) : base(options) { }
    }
}