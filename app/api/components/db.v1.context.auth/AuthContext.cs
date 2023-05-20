using Microsoft.EntityFrameworkCore;
using db.v1.context.auth.Models;
namespace db.v1.context.auth
{
    /// <summary>
    /// Контекст БД с аккаунтами пользователей
    /// </summary>
    public sealed class AuthContext : DbContext
    {
        /// <summary>
        /// Таблица с аккаунтами пользователей
        /// </summary>
        public DbSet<UserModel> TableUsers { get; set; }

        /// <summary>
        /// Представление с аккаунтами пользователей
        /// </summary>
        public DbSet<UserViewModel> ViewUsers { get; set; }

        public AuthContext(DbContextOptions options) : base(options) { }
    }
}