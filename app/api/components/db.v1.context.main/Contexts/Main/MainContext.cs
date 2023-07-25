using db.v1.context.main.Contexts.Main.Interfaces;
using db.v1.context.main.Entities.Dictionary;
using db.v1.context.main.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace db.v1.context.main.Contexts.Main
{
    public sealed class MainContext : DbContext, IUserContext, IDictionaryContext, IProfileContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<AppUserRoleEntity> AppUserRoles { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options) { }
    }
}