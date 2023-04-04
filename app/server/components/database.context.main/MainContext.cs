using Microsoft.EntityFrameworkCore;
using database.context.main.Models.Misc;
using database.context.main.Models.Data;
using database.context.main.Models.Profile.Languages;
using database.context.main.Models.Profile.LifePositions;
using database.context.main.Models.Profile.BaseInfo;
using database.context.main.Models;
namespace database.context.main
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