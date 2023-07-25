using db.v1.context.main.Entities.Dictionary;

namespace db.v1.context.main.Repositories.Dictionary
{
    public interface IDictionaryRepos
    {
        public AppUserRoleEntity? GetAppUserRole(string tag);
        public List<AppUserRoleEntity> GetAppUserRoles();

        public CountryEntity? GetCountry(Guid uuid);
        public List<CountryEntity> GetCountryList();

        public RegionEntity? GetRegion(Guid uuid);
        public List<RegionEntity> GetRegions();

        public CityEntity? GetCity(Guid uuid);
        public List<CityEntity> GetCities();

        public FamilyStatusEntity? GetFamilyStatus(Guid uuid);
        public List<FamilyStatusEntity> GetFamilyStatuses();
    }
}