using db.v1.context.main.Entities.Dictionary;
using Microsoft.EntityFrameworkCore;

namespace db.v1.context.main.Contexts.Main.Interfaces
{
    public interface IDictionaryContext
    {
        public DbSet<AppUserRoleEntity> AppUserRoles { get; set; }
    }
}