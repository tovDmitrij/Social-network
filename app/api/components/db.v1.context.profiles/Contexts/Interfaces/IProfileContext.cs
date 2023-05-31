using Microsoft.EntityFrameworkCore;
using db.v1.context.profiles.Models.Profiles.BaseInfo;
using db.v1.context.profiles.Models.Profiles.Carrers;
using db.v1.context.profiles.Models.Profiles.Languages;
using db.v1.context.profiles.Models.Profiles.LifePositions;
using db.v1.context.profiles.Models.Profiles.MilitaryServices;
namespace db.v1.context.profiles.Contexts.Interfaces
{
    /// <summary>
    /// Контекст БД с таблицами профилей пользователей
    /// </summary>
    public interface IProfileContext
    {
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

        /// <summary>
        /// Сохранить изменения в БД
        /// </summary>
        public int SaveChanges();
    }
}