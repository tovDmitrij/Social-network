using db.v1.context.main.Entities.Dictionary;
using Microsoft.EntityFrameworkCore;

namespace db.v1.context.main.Contexts.Main.Interfaces
{
    public interface IDictionaryContext
    {
        public DbSet<AppUserRoleEntity> AppUserRoles { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<RegionEntity> Regions { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<FamilyStatusEntity> FamilyStatuses { get; set; }
    }
}