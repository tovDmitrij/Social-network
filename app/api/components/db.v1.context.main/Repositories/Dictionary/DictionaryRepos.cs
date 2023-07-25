using db.v1.context.main.Contexts.Main.Interfaces;
using db.v1.context.main.Entities.Dictionary;

namespace db.v1.context.main.Repositories.Dictionary
{
    public sealed class DictionaryRepos : IDictionaryRepos
    {
        private readonly IDictionaryContext _db;

        public DictionaryRepos(IDictionaryContext db) => _db = db;

        public AppUserRoleEntity? GetAppUserRole(string tag) => _db.AppUserRoles.FirstOrDefault(x => x.Tag == tag);
        public List<AppUserRoleEntity> GetAppUserRoles() => _db.AppUserRoles.ToList();

        public CountryEntity? GetCountry(Guid uuid) => _db.Countries.FirstOrDefault(x => x.UUID == uuid);
        public List<CountryEntity> GetCountryList() => _db.Countries.ToList();

        public RegionEntity? GetRegion(Guid uuid) => _db.Regions.FirstOrDefault(x => x.UUID == uuid);
        public List<RegionEntity> GetRegions() => _db.Regions.ToList();

        public CityEntity? GetCity(Guid uuid) => _db.Cities.FirstOrDefault(x => x.UUID == uuid);
        public List<CityEntity> GetCities() => _db.Cities.ToList();

        public FamilyStatusEntity? GetFamilyStatus(Guid uuid) => _db.FamilyStatuses.FirstOrDefault(x => x.UUID == uuid);
        public List<FamilyStatusEntity> GetFamilyStatuses() => _db.FamilyStatuses.ToList();
    }
}