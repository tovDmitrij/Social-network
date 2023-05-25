using Microsoft.EntityFrameworkCore;
using db.v1.context.logs.Models;
namespace db.v1.context.logs
{
    /// <summary>
    /// Контекст БД с логами
    /// </summary>
    public sealed class LogContext : DbContext
    {
        /// <summary>
        /// Таблица логов
        /// </summary>
        public DbSet<LogModel> TableLogs { get; set; }

        public LogContext(DbContextOptions<LogContext> options) : base(options) { }
    }
}