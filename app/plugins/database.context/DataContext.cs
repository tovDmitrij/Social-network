using Microsoft.EntityFrameworkCore;
using database.context.Models;
namespace database.context
{
    /// <summary>
    /// Контекст базы данных социальной сети
    /// </summary>
    public sealed class DataContext: DbContext
    {
        public DbSet<UserModel> Users { get; init; }

        public DataContext(DbContextOptions options) : base(options) { }
    }
}