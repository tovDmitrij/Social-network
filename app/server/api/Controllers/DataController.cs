using Microsoft.AspNetCore.Mvc;
using database.context.Repos.Languages;
using database.context.Repos.LifePositions;
using database.context.Repos.Cities;
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
        [HttpGet("Language/{langID:int}/Get")]
        public IActionResult GetLanguage(int langID)
        {
            switch (_language.IsLanguageExist(langID))
            {
                case true:
                    return StatusCode(200, new
                    {
                        status = "Информация о языке была успешно сформированна",
                        data = _language.GetLanguage(langID)
                    });

                case false:
                    return StatusCode(404, new { status = "Языка с заданным идентификатором не существует в системе" });
            }
        }

        /// <summary>
        /// Получить список языков, определённых в системе
        /// </summary>
        [HttpGet("Languages/Get")]
        public IActionResult GetLanguages()
        {
            var languages = _language.GetLanguages();

            return languages.Any() ? 
                StatusCode(200, new
                {
                    status = "Список языков был успешно сформирован",
                    data = languages
                }) : 
                StatusCode(404, new { status = "Список языков пуст" });
        }

        #endregion



        #region Жизненные позиции

        /// <summary>
        /// Получить информацию о жизненной позиции по её идентификатору
        /// </summary>
        /// <param name="posID">Идентификатор жизненной позиции</param>
        [HttpGet("LifePositions/Position/{posID:int}/Get")]
        public IActionResult GetLifePosition(int posID)
        {
            switch (_position.IsLifePositionExist(posID))
            {
                case true:
                    return StatusCode(200, new
                    {
                        status = "Информация о жизненной позиции была успешно сформированна",
                        data = _position.GetLifePosition(posID)
                    });

                case false:
                    return StatusCode(404, new { status = "Жизненной позиции с заданным идентификатором не существует" });
            }
        }

        /// <summary>
        /// Получить список жизненных позиций, определённых в системе, по их типу
        /// </summary>
        /// <param name="typeID">Идентификатор типа жизненных позиций</param>
        [HttpGet("LifePositions/Type/{typeID:int}/Positions/Get")]
        public IActionResult GetLifePositionsByType(int typeID)
        {
            if (!_position.IsLifePositionTypeExist(typeID))
            {
                return StatusCode(404, new { status = "Тип жизненной позиции с заданным идентификатором не существует в системе" });
            }

            var positions = _position.GetLifePositions(typeID);
            switch (positions.Any())
            {
                case true:
                    return StatusCode(200, new
                    {
                        status = "Список жизненных позиций был успешно сформирован",
                        data = positions
                    });

                case false:
                    return StatusCode(404, new { status = "Список жизненных позиций пуст" });
            }
        }

        /// <summary>
        /// Получить список жизненных позиций, определённых в системе
        /// </summary>
        [HttpGet("LifePositions/Get")]
        public IActionResult GetLifePositions()
        {
            var positions = _position.GetLifePositions();

            return positions.Any() ?
                StatusCode(200, new
                {
                    status = "Список жизненных позиций был успешно сформирован",
                    data = positions
                }) :
                StatusCode(404, new { status = "Список жизненных позиций пуст" });
        }

        #endregion



        #region Места проживания

        /// <summary>
        /// Получить информацию о городе по его идентификатору
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        [HttpGet("City/{cityID:int}/Get")]
        public IActionResult GetCity(int cityID)
        {
            switch (_place.IsCityExist(cityID))
            {
                case true:
                    return StatusCode(200, new
                    {
                        status = "Информация о городе была успешно сформирована",
                        data = _place.GetCity(cityID)
                    });

                case false:
                    return StatusCode(404, new { status = "Города с заданным идентификатором не существует" });
            }
        }

        /// <summary>
        /// Получить информацию по городу по его идентификатору и идентификатору региона
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="regionID">Идентификатор региона</param>
        [HttpGet("Region/{regionID:int}/City/{cityID:int}/Get")]
        public IActionResult GetCityByRegion(int cityID,  int regionID)
        {
            if (!_place.IsCityExist(cityID))
            {
                return StatusCode(404, new { status = "Города с заданным идентификатором не существует" });
            }
            if (!_place.IsRegionExist(regionID))
            {
                return StatusCode(404, new { status = "Региона с заданным идентификатором не существует" });
            }
            if (!_place.IsCityExistInRegion(cityID, regionID))
            {
                return StatusCode(404, new { status = "Города в регионе с заданным идентификатором не существует" });
            }

            return StatusCode(200, new
            {
                status = "Информация по городу была успешно сформирована",
                data = _place.GetCity(cityID)
            });
        }

        /// <summary>
        /// Получить информацию по городу по его идентификатору и идентификатору страны
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="countryID">Идентификатор страны</param>
        [HttpGet("Country/{countryID:int}/City/{cityID:int}/Get")]
        public IActionResult GetCityByCountry(int cityID, int countryID)
        {
            if (!_place.IsCityExist(cityID))
            {
                return StatusCode(404, new { status = "Города с заданным идентификатором не существует" });
            }
            if (!_place.IsCountryExist(countryID))
            {
                return StatusCode(404, new { status = "Страны с заданным идентификатором не существует" });
            }
            if (!_place.IsCityExistInCountry(cityID, countryID))
            {
                return StatusCode(404, new { status = "Города в стране с заданным идентификатором не существует" });
            }

            return StatusCode(200, new
            {
                status = "Информация по городу была успешно сформирована",
                data = _place.GetCity(cityID)
            });
        }

        /// <summary>
        /// Получить список городов, определённых в системе
        /// </summary>
        [HttpGet("Cities/Get")]
        public IActionResult GetCities()
        {
            var cities = _place.GetCities();
            return cities.Any() ? 
                StatusCode(200, new
                {
                    status = "Список городов был успешно сформирован",
                    data = cities
                }) :
                StatusCode(404, new { status = "Список городов пуст" });
        }

        /// <summary>
        /// Получить список городов по идентификатору региона
        /// </summary>
        /// <param name="regionID">Идентификатор региона</param>
        [HttpGet("Region/{regionID:int}/Cities/Get")]
        public IActionResult GetCitiesByRegion(int regionID)
        {
            if (!_place.IsRegionExist(regionID))
            {
                return StatusCode(404, new { status = "Региона с заданным идентификатором не существует" });
            }

            var cities = _place.GetCitiesByRegion(regionID);
            switch (cities.Any())
            {
                case true:
                    return StatusCode(200, new
                    {
                        status = "Список городов был успешно сформирован",
                        data = cities
                    });

                case false:
                    return StatusCode(404, new { status = "Список городов для данного региона пуст" });
            }
        }

        /// <summary>
        /// Получить список городов по идентификатору страны
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        [HttpGet("Country/{countryID:int}/Cities/Get")]
        public IActionResult GetCitiesByCountry(int countryID)
        {
            if (!_place.IsCountryExist(countryID))
            {
                return StatusCode(404, new { status = "Страны с заданным идентификатором не существует" });
            }

            var cities = _place.GetCitiesByCountry(countryID);
            switch (cities.Any())
            {
                case true:
                    return StatusCode(200, new
                    {
                        status = "Список городов был успешно сформирован",
                        data = cities
                    });

                case false:
                    return StatusCode(404, new { status = "Список городов для заданной страны пуст" });
            }
        }



        /// <summary>
        /// Получить информацию по региону по его идентификатору
        /// </summary>
        /// <param name="regionID">Идентификатор региона</param>
        [HttpGet("Region/{regionID:int}/Get")]
        public IActionResult GetRegion(int regionID)
        {
            switch (_place.IsRegionExist(regionID))
            {
                case true:
                    return StatusCode(200, new
                    {
                        status = "Информация о регионе была успешно сформирована",
                        data = _place.GetRegion(regionID)
                    });

                case false:
                    return StatusCode(404, "Региона с заданным идентификатором не существует");
            }
        }

        /// <summary>
        /// Получить информацию о регионе по его идентификатору и идентификатору страны
        /// </summary>
        /// <param name="regionID">Идентификатор региона</param>
        /// <param name="countryID">Идентификатор страны</param>
        [HttpGet("Country/{countryID:int}/Region/{regionID:int}/Get")]
        public IActionResult GetRegionByCountry(int regionID, int countryID)
        {
            if (!_place.IsCountryExist(countryID))
            {
                return StatusCode(404, new { status = "Страны с заданным идентификатором не существует" });
            }
            if (!_place.IsRegionExist(regionID))
            {
                return StatusCode(404, new { status = "Региона с заданным идентификатором не существует" });
            }
            if (!_place.IsRegionExistInCountry(regionID, countryID))
            {
                return StatusCode(404, new { status = "Региона в стране с заданным идентификатором не существует" });
            }

            return StatusCode(200, new
            {
                status = "Информация по региону была успешно сформирована",
                data = _place.GetRegion(regionID)
            });
        }

        /// <summary>
        /// Получить список регионов, определённых в системе
        /// </summary>
        [HttpGet("Regions/Get")]
        public IActionResult GetRegions()
        {
            var regions = _place.GetRegions();
            switch (regions.Any())
            {
                case true:
                    return StatusCode(200, new
                    {
                        status = "Список регионов был успешно сформирован",
                        data = regions
                    });

                case false:
                    return StatusCode(404, new { status = "Список регионов пуст" });
            }
        }

        /// <summary>
        /// Получить список регионов по идентификатору страны
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        [HttpGet("Country/{countryID:int}/Regions/Get")]
        public IActionResult GetRegionsByCountry(int countryID)
        {
            if (!_place.IsCountryExist(countryID))
            {
                return StatusCode(404, new { status = "Страны с заданным идентификатором не существует" });
            }

            var regions = _place.GetRegionsByCountry(countryID);
            switch (regions.Any())
            {
                case true:
                    return StatusCode(200, new
                    {
                        status = "Список регионов был успешно сформирован",
                        data = regions
                    });

                case false:
                    return StatusCode(404, new { status = "Список регионов для заданной страны пуст" });
            }
        }



        /// <summary>
        /// Получить информацию о стране по её идентификатору
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        [HttpGet("Country/{countryID:int}/Get")]
        public IActionResult GetCountry(int countryID)
        {
            switch (_place.IsCountryExist(countryID))
            {
                case true:
                    return StatusCode(200, new
                    {
                        status = "Информация о стране была успешно сформирована",
                        data = _place.GetCountry(countryID)
                    });

                case false:
                    return StatusCode(404, new { status = "Страны с заданным идентификатором не существует" });
            }
        }

        /// <summary>
        /// Получить список стран, определённых в системе
        /// </summary>
        [HttpGet("Countries/Get")]
        public IActionResult GetCountries()
        {
            var countries = _place.GetCountries();
            switch (countries.Any())
            {
                case true:
                    return StatusCode(200, new
                    {
                        status = "Список стран был успешно сформирован",
                        data = countries
                    });

                case false:
                    return StatusCode(404, new
                    {
                        status = "Список стран пуст"
                    });
            }
        }

        #endregion



    }
}