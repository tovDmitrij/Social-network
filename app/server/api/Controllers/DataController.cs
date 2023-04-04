using Microsoft.AspNetCore.Mvc;
using database.context.main.Repos.Languages;
using database.context.main.Repos.LifePositions;
using database.context.main.Repos.Cities;
namespace api.Controllers
{
    /// <summary>
    /// Получение различной статичной информации из системы
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public sealed class DataController: BaseController
    {
        /// <summary>
        /// Взаимодействие с таблицей языков
        /// </summary>
        private readonly ILanguageRepos _language;

        /// <summary>
        /// Взаимодействие с таблицами жизненных позиций
        /// </summary>
        private readonly ILifePositionsRepos _position;

        /// <summary>
        /// Взаимодействие с таблицами мест проживания
        /// </summary>
        private readonly IPlaceOfLivingRepos _place;

        public DataController(ILanguageRepos language, ILifePositionsRepos lifePositions, IPlaceOfLivingRepos placeOfLiving)
        {
            _language = language;
            _position = lifePositions;
            _place = placeOfLiving;
        }



        #region Языки

        /// <summary>
        /// Получить информацию о языке по его идентификатору
        /// </summary>
        /// <param name="langID">Идентификатор языка</param>
        [HttpGet("Language/Get/langID={langID:int}")]
        public IActionResult GetLanguage(int langID) => _language.IsLanguageExist(langID) ? 
            LanguageOk(_language.GetLanguage(langID)) : 
            LanguageNotFound;

        /// <summary>
        /// Получить список языков, определённых в системе
        /// </summary>
        [HttpGet("Languages/Get")]
        public IActionResult GetLanguages()
        {
            var languages = _language.GetLanguages();
            return languages.Any() ? 
                LanguagesOk(languages) : 
                LanguagesNotFound;
        }

        #endregion



        #region Жизненные позиции

        /// <summary>
        /// Получить информацию о жизненной позиции по её идентификатору
        /// </summary>
        /// <param name="posID">Идентификатор жизненной позиции</param>
        [HttpGet("LifePositions/Position/Get/posID={posID:int}")]
        public IActionResult GetLifePosition(int posID) => _position.IsLifePositionExist(posID) ? 
            LifePositionOk(_position.GetLifePosition(posID)) : 
            LifePositionNotFound;

        /// <summary>
        /// Получить список жизненных позиций, определённых в системе, по их типу
        /// </summary>
        /// <param name="typeID">Идентификатор типа жизненных позиций</param>
        [HttpGet("LifePositions/Type/typeID={typeID:int}/Positions/Get")]
        public IActionResult GetLifePositionsByType(int typeID)
        {
            if (!_position.IsLifePositionTypeExist(typeID))
            {
                return LifePositionTypeNotFound;
            }

            var positions = _position.GetLifePositions(typeID);
            return positions.Any() ? 
                LifePositionsOk(positions) : 
                LifePositionsByTypeNotFound;
        }

        /// <summary>
        /// Получить список жизненных позиций, определённых в системе
        /// </summary>
        [HttpGet("LifePositions/Get")]
        public IActionResult GetLifePositions()
        {
            var positions = _position.GetLifePositions();

            return positions.Any() ?
                LifePositionsOk(positions) :
                LifePositionsNotFound;
        }

        #endregion



        #region Места проживания

        /// <summary>
        /// Получить информацию о городе по его идентификатору
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        [HttpGet("City/Get/cityID={cityID:int}")]
        public IActionResult GetCity(int cityID) => _place.IsCityExist(cityID) ?
            CityOk(_place.GetCity(cityID)) :
            CityNotFound;

        /// <summary>
        /// Получить информацию по городу по его идентификатору и идентификатору региона
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="regionID">Идентификатор региона</param>
        [HttpGet("Region/regionID={regionID:int}/City/Get/cityID={cityID:int}")]
        public IActionResult GetCityByRegion(int cityID,  int regionID)
        {
            if (!_place.IsCityExist(cityID)) return CityNotFound;
            if (!_place.IsRegionExist(regionID)) return RegionNotFound;
            if (!_place.IsCityExistInRegion(cityID, regionID)) return CityInRegionNotFound;

            return CityOk(_place.GetCity(cityID));
        }

        /// <summary>
        /// Получить информацию по городу по его идентификатору и идентификатору страны
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="countryID">Идентификатор страны</param>
        [HttpGet("Country/countryID={countryID:int}/City/Get/cityID={cityID:int}")]
        public IActionResult GetCityByCountry(int cityID, int countryID)
        {
            if (!_place.IsCityExist(cityID)) return CityNotFound;
            if (!_place.IsCountryExist(countryID)) return CountryNotFound;
            if (!_place.IsCityExistInCountry(cityID, countryID)) return CityInCountryNotFound;

            return CityOk(_place.GetCity(cityID));
        }

        /// <summary>
        /// Получить список городов, определённых в системе
        /// </summary>
        [HttpGet("Cities/Get")]
        public IActionResult GetCities()
        {
            var cities = _place.GetCities();
            return cities.Any() ? 
                CitiesOk(cities) :
                CitiesNotFound;
        }

        /// <summary>
        /// Получить список городов по идентификатору региона
        /// </summary>
        /// <param name="regionID">Идентификатор региона</param>
        [HttpGet("Region/regionID={regionID:int}/Cities/Get")]
        public IActionResult GetCitiesByRegion(int regionID)
        {
            if (!_place.IsRegionExist(regionID)) return RegionNotFound;

            var cities = _place.GetCitiesByRegion(regionID);
            return cities.Any() ? 
                CitiesOk(cities) : 
                CitiesByRegionNotFound;
        }

        /// <summary>
        /// Получить список городов по идентификатору страны
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        [HttpGet("Country/countryID={countryID:int}/Cities/Get")]
        public IActionResult GetCitiesByCountry(int countryID)
        {
            if (!_place.IsCountryExist(countryID)) return CountryNotFound;

            var cities = _place.GetCitiesByCountry(countryID);
            return cities.Any() ?
                CitiesOk(cities) :
                CitiesByCountryNotFound;
        }



        /// <summary>
        /// Получить информацию по региону по его идентификатору
        /// </summary>
        /// <param name="regionID">Идентификатор региона</param>
        [HttpGet("Region/Get/regionID={regionID:int}")]
        public IActionResult GetRegion(int regionID) => _place.IsRegionExist(regionID) ?
            RegionOk(_place.GetRegion(regionID)) :
            RegionNotFound;

        /// <summary>
        /// Получить информацию о регионе по его идентификатору и идентификатору страны
        /// </summary>
        /// <param name="regionID">Идентификатор региона</param>
        /// <param name="countryID">Идентификатор страны</param>
        [HttpGet("Country/countryID={countryID:int}/Region/Get/regionID={regionID:int}")]
        public IActionResult GetRegionByCountry(int regionID, int countryID)
        {
            if (!_place.IsCountryExist(countryID)) return CountryNotFound;
            if (!_place.IsRegionExist(regionID)) return RegionNotFound;
            if (!_place.IsRegionExistInCountry(regionID, countryID)) return RegionByCountryNotFound;

            return RegionOk(_place.GetRegion(regionID));
        }

        /// <summary>
        /// Получить список регионов, определённых в системе
        /// </summary>
        [HttpGet("Regions/Get")]
        public IActionResult GetRegions()
        {
            var regions = _place.GetRegions();
            return regions.Any() ?
                RegionsOk(regions) :
                RegionsNotFound;
        }

        /// <summary>
        /// Получить список регионов по идентификатору страны
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        [HttpGet("Country/countryID={countryID:int}/Regions/Get")]
        public IActionResult GetRegionsByCountry(int countryID)
        {
            if (!_place.IsCountryExist(countryID)) return CountryNotFound;

            var regions = _place.GetRegionsByCountry(countryID);
            return regions.Any() ?
                RegionsOk(regions) :
                RegionByCountryNotFound;
        }



        /// <summary>
        /// Получить информацию о стране по её идентификатору
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        [HttpGet("Country/Get/countryID={countryID:int}")]
        public IActionResult GetCountry(int countryID) => _place.IsCountryExist(countryID) ?
            CountryOk(_place.GetCountry(countryID)) :
            CountryNotFound;

        /// <summary>
        /// Получить список стран, определённых в системе
        /// </summary>
        [HttpGet("Countries/Get")]
        public IActionResult GetCountries()
        {
            var countries = _place.GetCountries();
            return countries.Any() ?
                CountriesOk(countries) :
                CountriesNotFound;
        }

        #endregion



    }
}