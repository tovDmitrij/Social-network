using db.v1.context.main.Entities.Dictionary;

namespace db.v1.context.main.Repositories.Dictionary
{
    public interface IDictionaryRepos
    {
        public AppUserRoleEntity? GetAppUserRole(string tag);
        public List<AppUserRoleEntity> GetAppUserRoles();

        public CountryEntity? GetCountry(int id);
        public List<CountryEntity> GetCountries();

        public RegionEntity? GetRegion(int id);
        public List<RegionEntity> GetRegions();

        public CityEntity? GetCity(int id);
        public List<CityEntity> GetCities();

        public FamilyStatusEntity? GetFamilyStatus(int id);
        public List<FamilyStatusEntity> GetFamilyStatuses();
    }
}