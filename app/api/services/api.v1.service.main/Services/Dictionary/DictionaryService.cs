using api.v1.service.main.Exceptions;
using db.v1.context.main.Entities.Dictionary;
using db.v1.context.main.Repositories.Dictionary;

namespace api.v1.service.main.Services.Dictionary
{
    public sealed class DictionaryService : IDictionaryService
    {
        private readonly IDictionaryRepos _dictRepos;

        public DictionaryService(IDictionaryRepos dictRepos) => _dictRepos = dictRepos;



        public List<FamilyStatusEntity> GetFamilyStatuses() =>
            CheckIfEmpty(_dictRepos.GetFamilyStatuses(), "Список семейных статусов пуст");

        public List<CountryEntity> GetCountries() =>
            CheckIfEmpty(_dictRepos.GetCountries(), "Список стран пуст");

        public List<RegionEntity> GetRegions() =>
            CheckIfEmpty(_dictRepos.GetRegions(), "Список регионов пуст");

        public List<CityEntity> GetCities() =>
            CheckIfEmpty(_dictRepos.GetCities(), "Список городов пуст");



        private static List<T> CheckIfEmpty<T>(List<T> data, string error) where T : BaseDictionaryEntity => 
            data.Any() ? data : throw new NoContentException(error);
    }
}