using db.v1.context.dictionary.Models.Places;
namespace db.v1.context.dictionary.Repos.Places
{
    /// <summary>
    /// Взаимодействие с таблицами городов, регионов и стран мира
    /// </summary>
    internal sealed class PlaceRepos : IPlaceRepos
    {
        /// <summary>
        /// База данных словаря
        /// </summary>
        private readonly DictionaryContext _db;

        public PlaceRepos(DictionaryContext db) => _db = db;



        #region Города

        public bool IsCityExist(int cityID) => _db.TableCities
            .Any(city => city.ID == cityID);

        public bool IsCityExistInRegion(int cityID, int regionID) => _db.TableCities
            .Any(city => city.ID == cityID && city.RegionID == regionID);

        public bool IsCityExistInCountry(int cityID, int countryID) => _db.ViewPlaces
            .Any(city => city.CityID == cityID && city.CountryID == countryID);

        public CityModel? GetCity(int cityID) => _db.TableCities
            .FirstOrDefault(city => city.ID == cityID);

        public IEnumerable<CityModel>? GetCities() => _db.TableCities
            .Select(city =>  city);

        public IEnumerable<CityModel>? GetCitiesByRegion(int regionID) => _db.TableCities
            .Where(city => city.RegionID == regionID);

        public IEnumerable<CityModel>? GetCitiesByCountry(int countryID) => _db.TableCities
            .Where(city => _db.ViewPlaces
                .Where(viewCities => viewCities.CountryID == countryID)
                    .Any(viewCity => viewCity.CityID == city.ID));

        #endregion



        #region Регионы

        public bool IsRegionExist(int regionID) => _db.TableRegions
            .Any(region => region.ID == regionID);

        public bool IsRegionExistInCountry(int regionID, int countryID) => _db.TableRegions
            .Any(region => region.ID == regionID && region.CountryID == countryID);

        public RegionModel? GetRegion(int regionID) => _db.TableRegions
            .FirstOrDefault(region => region.ID == regionID);

        public IEnumerable<RegionModel>? GetRegions() => _db.TableRegions
            .Select(region => region);

        public IEnumerable<RegionModel>? GetRegionsByCountry(int countryID) => _db.TableRegions
            .Where(region => region.CountryID == countryID);

        #endregion



        #region Страны

        public bool IsCountryExist(int countryID) => _db.TableCountries
            .Any(country => country.ID == countryID);

        public CountryModel? GetCountry(int countryID) => _db.TableCountries
            .FirstOrDefault(country => country.ID == countryID);

        public IEnumerable<CountryModel>? GetCountries() => _db.TableCountries
            .Select(country => country);

        #endregion



    }
}