using Microsoft.EntityFrameworkCore;
using database.context.Models.Auth;
using database.context.Models.Profile;
using database.context.Models.Profile.Languages;
namespace database.context
{
    /// <summary>
    /// Контекст базы данных социальной сети
    /// </summary>
    public sealed class DataContext : DbContext
    {
        /// <summary>
        /// Таблица с аккаунтами пользователей
        /// </summary>
        public DbSet<UserAuthModel> Users { get; set; }



        #region Профиль пользователя

        /// <summary>
        /// Таблица с базовой информацией о профилях пользователей
        /// </summary>
        public DbSet<ProfileAuthModel> TableProfileBaseInfo { get; set; }

        /// <summary>
        /// Представление с базовой информацией о профилях пользователей
        /// </summary>
        public DbSet<UserBaseInfoModel> ViewProfileBaseInfo { get; set; }

        /// <summary>
        /// Таблица с выбранными пользователями языками в профиле
        /// </summary>
        public DbSet<LanguageModel> TableProfileLanguages { get; set; }

        /// <summary>
        /// Представление с выбранными пользователями языками в профиле
        /// </summary>
        public DbSet<ProfileLanguageModel> ViewProfileLanguages { get; set; }

        #endregion



        public DataContext(DbContextOptions options) : base(options) { }
    }
}