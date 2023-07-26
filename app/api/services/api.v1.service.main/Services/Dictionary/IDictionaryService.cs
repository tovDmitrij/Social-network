using db.v1.context.main.Entities.Dictionary;

namespace api.v1.service.main.Services.Dictionary
{
    public interface IDictionaryService
    {
        public List<FamilyStatusEntity> GetFamilyStatuses();
        public List<CountryEntity> GetCountries();
        public List<RegionEntity> GetRegions();
        public List<CityEntity> GetCities();
    }
}