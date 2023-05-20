﻿using Microsoft.EntityFrameworkCore;
using db.v1.context.profiles.Models.BaseInfo;
using db.v1.context.profiles.Models.Careers;
using db.v1.context.profiles.Models.Languages;
using db.v1.context.profiles.Models.LifePositions;
using db.v1.context.profiles.Models.MilitaryServices;
namespace db.v1.context.profiles
{
    /// <summary>
    /// Контекст БД с профилями пользователей
    /// </summary>
    public sealed class ProfileContext : DbContext
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

        public ProfileContext(DbContextOptions options) : base(options) { }
    }
}