using Microsoft.EntityFrameworkCore;

namespace database.context
{
    /// <summary>
    /// Контекст базы данных социальной сети
    /// </summary>
    public class DataContext: DbContext
    {
        public DbSet<T> Users { get; init; }

        public DataContext(DbContextOptions options) : base(options) { }
    }
}