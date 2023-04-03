using Microsoft.EntityFrameworkCore;
using database.context.Models.Misc;
using database.context.Models.Auth;
using database.context.Models.Data;
using database.context.Models.Profile;
using database.context.Models.Profile.Languages;
using database.context.Models.Profile.LifePositions;
namespace database.context
{
    /// <summary>
    /// Контекст базы данных социальной сети
    /// </summary>
    public sealed class DataContext : DbContext
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
        /// Представление с информацией обо всех городах на платформе
        /// </summary>
        public DbSet<CitiesModel> ViewCities { get; set; }

        /// <summary>
        /// Таблица с информацией обо всех семейных положениях на платформе
        /// </summary>
        public DbSet<FamilyStatusModel> TableFamilyStatuses { get; set; }

        #endregion



        public DataContext(DbContextOptions options) : base(options) { }
    }
}