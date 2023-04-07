using Microsoft.AspNetCore.Mvc;
using database.context.main.Repos.Languages;
using database.context.main.Repos.LifePositions;
using database.context.main.Repos.Cities;
using database.context.main.Repos.FamilyStatuses;
using database.context.main.Models.Misc;
using database.context.main.Models.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api.Controllers
{
    /// <summary>
    /// Получение различной статичной информации из системы
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public sealed class DataController: ControllerBase
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

        /// <summary>
        /// Взаимодействие с таблицей семейных положений пользователей
        /// </summary>
        private readonly IFamilyStatusRepos _status;

        public DataController(
            ILanguageRepos language, 
            ILifePositionsRepos lifePositions, 
            IPlaceOfLivingRepos placeOfLiving,
            IFamilyStatusRepos status)
        {
            _language = language;
            _position = lifePositions;
            _place = placeOfLiving;
            _status = status;
        }



        #region Языки

        /// <summary>
        /// Получить информацию о языке по его идентификатору
        /// </summary>
        /// <param name="langID">Идентификатор языка</param>
        [ProducesResponseType(typeof(LanguageModel), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("Language/langID={langID:int}/Get")]
        public IActionResult GetLanguage(int langID) => _language.IsLanguageExist(langID) ?
            StatusCode(200, new { status = "Информация о языке была успешно сформирована", data = _language.GetLanguage(langID) }) :
            StatusCode(404, new { status = "Языка с заданным идентификатором не существует" });

        /// <summary>
        /// Получить список языков, определённых в системе
        /// </summary>
        [ProducesResponseType(typeof(IEnumerable<LanguageModel>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("Languages/Get")]
        public IActionResult GetLanguages()
        {
            var languages = _language.GetLanguages();
            return languages.Any() ?
                StatusCode(200, new { status = "Список языков был успешно сформирован", data = languages }) :
                StatusCode(404, new { status = "Список языков пуст" });
        }

        #endregion



        #region Жизненные позиции

        /// <summary>
        /// Получить информацию о жизненной позиции по её идентификатору
        /// </summary>
        /// <param name="posID">Идентификатор жизненной позиции</param>
        [ProducesResponseType(typeof(LifePositionModel), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("LifePositions/Position/posID={posID:int}/Get")]
        public IActionResult GetLifePosition(int posID) => _position.IsLifePositionExist(posID) ?
            StatusCode(200, new { status = "Информация о жизненной позиции была успешно сформирована", data = _position.GetLifePosition(posID) }) :
            StatusCode(404, new { status = "Жизненной позиции с заданным идентификатором не существует" });

        /// <summary>
        /// Получить список жизненных позиций, определённых в системе, по их типу
        /// </summary>
        /// <param name="typeID">Идентификатор типа жизненных позиций</param>
        [ProducesResponseType(typeof(IEnumerable<LifePositionModel>),200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("LifePositions/Type/typeID={typeID:int}/Positions/Get")]
        public IActionResult GetLifePositionsByType(int typeID)
        {
            if (!_position.IsLifePositionTypeExist(typeID)) 
                return StatusCode(404, new { status = "Типа жизненной позиции с заданным идентификатором не существует" });

            var positions = _position.GetLifePositions(typeID);
            return positions.Any() ?
                StatusCode(200, new { status = "Список жизненных позиций был успешно сформирован", data = positions }) :
                StatusCode(404, new { status = "Список жизненных позиций заданного типа пуст" });
        }

        /// <summary>
        /// Получить список жизненных позиций, определённых в системе
        /// </summary>
        [ProducesResponseType(typeof(IEnumerable<LifePositionModel>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("LifePositions/Get")]
        public IActionResult GetLifePositions()
        {
            var positions = _position.GetLifePositions();

            return positions.Any() ?
                StatusCode(200, new { status = "Список жизненных позиций был успешно сформирован", data = positions }) :
                StatusCode(404, new { status = "Список жизненных позиций пуст" });
        }

        #endregion



        #region Места проживания

        /// <summary>
        /// Получить информацию о городе по его идентификатору
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        [ProducesResponseType(typeof(CityModel), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("City/cityID={cityID:int}/Get")]
        public IActionResult GetCity(int cityID) => _place.IsCityExist(cityID) ?
            StatusCode(200, new { status = "Информация о городе была успешно сформирована", data = _place.GetCity(cityID) }) :
            StatusCode(404, new { status = "Города с заданным идентификатором не существует" });

        /// <summary>
        /// Получить информацию по городу по его идентификатору и идентификатору региона
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="regionID">Идентификатор региона</param>
        [ProducesResponseType(typeof(CityModel), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("Region/regionID={regionID:int}/City/cityID={cityID:int}/Get")]
        public IActionResult GetCityByRegion(int cityID,  int regionID)
        {
            if (!_place.IsCityExist(cityID)) 
                return StatusCode(404, new { status = "Города с заданным идентификатором не существует" });
            if (!_place.IsRegionExist(regionID)) 
                return StatusCode(404, new { status = "Региона с заданным идентификатором не существует" });
            if (!_place.IsCityExistInRegion(cityID, regionID)) 
                return StatusCode(404, new { status = "Города в регионе с заданным идентификатором не существует" });

            return StatusCode(200, new { status = "Информация о городе была успешно сформирована", data = _place.GetCity(cityID) });
        }

        /// <summary>
        /// Получить информацию по городу по его идентификатору и идентификатору страны
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="countryID">Идентификатор страны</param>
        [ProducesResponseType(typeof(CityModel), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("Country/countryID={countryID:int}/City/Get/cityID={cityID:int}")]
        public IActionResult GetCityByCountry(int cityID, int countryID)
        {
            if (!_place.IsCityExist(cityID)) 
                return StatusCode(404, new { status = "Города с заданным идентификатором не существует" });
            if (!_place.IsCountryExist(countryID)) 
                return StatusCode(404, new { status = "Страны с заданным идентификатором не существует" });
            if (!_place.IsCityExistInCountry(cityID, countryID)) 
                return StatusCode(404, new { status = "Города в стране с заданным идентификатором не существует" });

            return StatusCode(200, new { status = "Информация о городе была успешно сформирована", data = _place.GetCity(cityID) });
        }

        /// <summary>
        /// Получить список городов, определённых в системе
        /// </summary>
        [ProducesResponseType(typeof(IEnumerable<CityModel>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("Cities/Get")]
        public IActionResult GetCities()
        {
            var cities = _place.GetCities();
            return cities.Any() ?
                StatusCode(200, new { status = "Список городов был успешно сформирован", data = cities }) :
                StatusCode(404, new { status = "Список городов пуст" });
        }

        /// <summary>
        /// Получить список городов по идентификатору региона
        /// </summary>
        /// <param name="regionID">Идентификатор региона</param>
        [ProducesResponseType(typeof(IEnumerable<CityModel>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("Region/regionID={regionID:int}/Cities/Get")]
        public IActionResult GetCitiesByRegion(int regionID)
        {
            if (!_place.IsRegionExist(regionID)) 
                return StatusCode(404, new { status = "Региона с заданным идентификатором не существует" });

            var cities = _place.GetCitiesByRegion(regionID);
            return cities.Any() ?
                StatusCode(200, new { status = "Список городов был успешно сформирован", data = cities }) :
                StatusCode(404, new { status = "Список городов для заданного региона пуст" });
        }

        /// <summary>
        /// Получить список городов по идентификатору страны
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        [ProducesResponseType(typeof(IEnumerable<CityModel>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("Country/countryID={countryID:int}/Cities/Get")]
        public IActionResult GetCitiesByCountry(int countryID)
        {
            if (!_place.IsCountryExist(countryID)) 
                return StatusCode(404, new { status = "Страны с заданным идентификатором не существует" });

            var cities = _place.GetCitiesByCountry(countryID);
            return cities.Any() ?
                StatusCode(200, new { status = "Список городов был успешно сформирован", data = cities }) :
                StatusCode(404, new { status = "Список городов для заданной страны пуст" });
        }



        /// <summary>
        /// Получить информацию по региону по его идентификатору
        /// </summary>
        /// <param name="regionID">Идентификатор региона</param>
        [ProducesResponseType(typeof(RegionModel), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("Region/Get/regionID={regionID:int}")]
        public IActionResult GetRegion(int regionID) => _place.IsRegionExist(regionID) ?
            StatusCode(200, new { status = "Информация о регионе была успешно сформирована", data = _place.GetRegion(regionID) }) :
            StatusCode(404, new { status = "Региона с заданным идентификатором не существует" });

        /// <summary>
        /// Получить информацию о регионе по его идентификатору и идентификатору страны
        /// </summary>
        /// <param name="regionID">Идентификатор региона</param>
        /// <param name="countryID">Идентификатор страны</param>
        [ProducesResponseType(typeof(RegionModel), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("Country/countryID={countryID:int}/Region/Get/regionID={regionID:int}")]
        public IActionResult GetRegionByCountry(int regionID, int countryID)
        {
            if (!_place.IsCountryExist(countryID)) 
                return StatusCode(404, new { status = "Страны с заданным идентификатором не существует" });
            if (!_place.IsRegionExist(regionID)) 
                return StatusCode(404, new { status = "Региона с заданным идентификатором не существует" });
            if (!_place.IsRegionExistInCountry(regionID, countryID)) 
                return StatusCode(404, new { status = "Региона в стране с заданным идентификатором не существует" });

            return StatusCode(200, new { status = "Информация о регионе была успешно сформирована", data = _place.GetRegion(regionID) });
        }

        /// <summary>
        /// Получить список регионов, определённых в системе
        /// </summary>
        [ProducesResponseType(typeof(IEnumerable<RegionModel>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("Regions/Get")]
        public IActionResult GetRegions()
        {
            var regions = _place.GetRegions();
            return regions.Any() ?
                StatusCode(200, new { status = "Список регионов был успешно сформирован", data = regions }) :
                StatusCode(404, new { status = "Список регионов пуст" });
        }

        /// <summary>
        /// Получить список регионов по идентификатору страны
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        [ProducesResponseType(typeof(IEnumerable<RegionModel>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("Country/countryID={countryID:int}/Regions/Get")]
        public IActionResult GetRegionsByCountry(int countryID)
        {
            if (!_place.IsCountryExist(countryID)) 
                return StatusCode(404, new { status = "Страны с заданным идентификатором не существует" });

            var regions = _place.GetRegionsByCountry(countryID);
            return regions.Any() ?
                StatusCode(200, new { status = "Список регионов был успешно сформирован", data = regions }) :
                StatusCode(404, new { status = "Региона в стране с заданным идентификатором не существует" });
        }



        /// <summary>
        /// Получить информацию о стране по её идентификатору
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        [ProducesResponseType(typeof(CountryModel), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("Country/Get/countryID={countryID:int}")]
        public IActionResult GetCountry(int countryID) => _place.IsCountryExist(countryID) ?
            StatusCode(200, new { status = "Информация о стране была успешно сформирована", data = _place.GetCountry(countryID) }) :
            StatusCode(404, new { status = "Страны с заданным идентификатором не существует" });

        /// <summary>
        /// Получить список стран, определённых в системе
        /// </summary>
        [ProducesResponseType(typeof(IEnumerable<CountryModel>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("Countries/Get")]
        public IActionResult GetCountries()
        {
            var countries = _place.GetCountries();
            return countries.Any() ?
                StatusCode(200, new { status = "Список стран был успешно сформирован", data = countries }) :
                StatusCode(404, new { status = "Список стран пуст" });
        }

        #endregion



        #region Семейные положения пользователей

        /// <summary>
        /// Получить информацию о семейном положении по его идентификатору
        /// </summary>
        /// <param name="statusID">Идентификатор статуса</param>
        [ProducesResponseType(typeof(FamilyStatusModel), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("FamilyStatus/Get/statusID={statusID:int}")]
        public IActionResult GetFamilyStatus(int statusID) => _status.IsStatusExist(statusID) ?
            StatusCode(200, new { status = "Информация о семейном положении была успешно сформирована", data = _status.GetStatus(statusID) }) :
            StatusCode(404, new { status = "Семейного положения с заданным идентификатором не существует" });

        /// <summary>
        /// Получить список семейных положений
        /// </summary>
        [ProducesResponseType(typeof(IEnumerable<FamilyStatusModel>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [HttpGet("FamilyStatuses/Get")]
        public IActionResult GetFamilyStatuses()
        {
            var statuses = _status.GetStatuses();
            return statuses.Any() ?
                StatusCode(200, new { status = "Список семейных положений был успешно сформирован", data = statuses }) :
                StatusCode(404, new { status = "Список семейных положений пуст" });
        }

        #endregion



    }
}