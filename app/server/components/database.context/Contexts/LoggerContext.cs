﻿using Microsoft.EntityFrameworkCore;
using database.context.Models.Data;
namespace database.context.Contexts
{
    /// <summary>
    /// Контекст таблицы логов в базе данных социальной сети
    /// </summary>
    public sealed class LoggerContext : DbContext
    {
        /// <summary>
        /// Таблица логов
        /// </summary>
        public DbSet<LogModel> TableLogs { get; set; }

        public LoggerContext() { }

        public LoggerContext(DbContextOptions<LoggerContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=social_network;Username=postgres;Password=123456;Timeout=300;CommandTimeout=300");
    }
}