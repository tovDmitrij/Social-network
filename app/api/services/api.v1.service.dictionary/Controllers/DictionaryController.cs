using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using db.v1.context.dictionary.Wrappers;
namespace api.service.data.Controllers
{
    /// <summary>
    /// Получение различной справочной информации
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public sealed class DictionaryController : ControllerBase
    {
        /// <summary>
        /// Взаимодействие с БД-справочником
        /// </summary>
        private readonly IDictionaryWrapper _dict;

        public DictionaryController(IDictionaryWrapper dict) 
        { 
            _dict = dict; 
        }



        #region Языки

        /// <summary>
        /// Получить информацию о языке по его идентификатору
        /// </summary>
        /// <param name="lang_id">Идентификатор языка</param>
        [HttpGet("Languages/{lang_id:int}")]
        public IActionResult GetLanguage(int lang_id) => _dict.Langs.IsLanguageExist(lang_id) ?
            StatusCode(200, new 
            { 
                status = "Информация о языке была успешно сформирована", 
                data = _dict.Langs.GetLanguage(lang_id) 
            }) :
            StatusCode(404, new 
            { 
                status = "Языка с заданным идентификатором не существует" 
            });

        /// <summary>
        /// Получить список языков, определённых в системе
        /// </summary>
        [HttpGet("Languages")]
        public IActionResult GetLanguages()
        {
            var languages = _dict.Langs.GetLanguages();
            return languages.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список языков был успешно сформирован", 
                    data = languages 
                }) :
                StatusCode(404, new 
                { 
                    status = "Список языков пуст" 
                });
        }

        #endregion



        #region Жизненные позиции

        /// <summary>
        /// Получить информацию о жизненной позиции по её идентификатору
        /// </summary>
        /// <param name="pos_id">Идентификатор жизненной позиции</param>
        [HttpGet("LifePositions/{pos_id:int}")]
        public IActionResult GetLifePosition(int pos_id) => _dict.Positions.IsLifePositionExist(pos_id) ?
            StatusCode(200, new 
            { 
                status = "Информация о жизненной позиции была успешно сформирована", 
                data = _dict.Positions.GetLifePosition(pos_id) 
            }) :
            StatusCode(404, new 
            { 
                status = "Жизненной позиции с заданным идентификатором не существует" 
            });

        /// <summary>
        /// Получить список жизненных позиций, определённых в системе, по их типу
        /// </summary>
        /// <param name="type_id">Идентификатор типа жизненных позиций</param>
        [HttpGet("LifePositions/Type/{type_id:int}")]
        public IActionResult GetLifePositionsByType(int type_id)
        {
            if (!_dict.Positions.IsLifePositionTypeExist(type_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Типа жизненной позиции с заданным идентификатором не существует" 
                });
            }

            var positions = _dict.Positions.GetLifePositions(type_id);
            return positions.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список жизненных позиций был успешно сформирован", 
                    data = positions 
                }) :
                StatusCode(404, new 
                { 
                    status = "Список жизненных позиций заданного типа пуст" 
                });
        }

        /// <summary>
        /// Получить список жизненных позиций, определённых в системе
        /// </summary>
        [HttpGet("LifePositions")]
        public IActionResult GetLifePositions()
        {
            var positions = _dict.Positions.GetLifePositions();
            return positions.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список жизненных позиций был успешно сформирован", 
                    data = positions 
                }) :
                StatusCode(404, new 
                { 
                    status = "Список жизненных позиций пуст" 
                });
        }

        #endregion



        #region Места проживания

        /// <summary>
        /// Получить информацию о городе по его идентификатору
        /// </summary>
        /// <param name="city_id">Идентификатор города</param>
        [HttpGet("Cities/{city_id:int}")]
        public IActionResult GetCity(int city_id) => _dict.Places.IsCityExist(city_id) ?
            StatusCode(200, new 
            { 
                status = "Информация о городе была успешно сформирована", 
                data = _dict.Places.GetCity(city_id) 
            }) :
            StatusCode(404, new 
            { 
                status = "Города с заданным идентификатором не существует" 
            });

        /// <summary>
        /// Получить информацию по городу по его идентификатору и идентификатору региона
        /// </summary>
        /// <param name="city_id">Идентификатор города</param>
        /// <param name="region_id">Идентификатор региона</param>
        [HttpGet("Regions/{region_id:int}/Cities/{city_id:int}")]
        public IActionResult GetCityByRegion(int city_id, int region_id)
        {
            if (!_dict.Places.IsCityExist(city_id))
            {
                return StatusCode(404, new
                {
                    status = "Города с заданным идентификатором не существует"
                });
            }
            if (!_dict.Places.IsRegionExist(region_id))
            {
                return StatusCode(404, new
                {
                    status = "Региона с заданным идентификатором не существует"
                });
            }
            if (!_dict.Places.IsCityExistInRegion(city_id, region_id))
            {
                return StatusCode(404, new
                {
                    status = "Города в регионе с заданным идентификатором не существует"
                });
            }

            return StatusCode(200, new 
            { 
                status = "Информация о городе была успешно сформирована", 
                data = _dict.Places.GetCity(city_id) 
            });
        }

        /// <summary>
        /// Получить информацию по городу по его идентификатору и идентификатору страны
        /// </summary>
        /// <param name="city_id">Идентификатор города</param>
        /// <param name="country_id">Идентификатор страны</param>
        [HttpGet("Countries/{country_id:int}/Cities/{city_id:int}")]
        public IActionResult GetCityByCountry(int city_id, int country_id)
        {
            if (!_dict.Places.IsCityExist(city_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Города с заданным идентификатором не существует" 
                });
            }
            if (!_dict.Places.IsCountryExist(country_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Страны с заданным идентификатором не существует" 
                });
            }
            if (!_dict.Places.IsCityExistInCountry(city_id, country_id))
            {
                return StatusCode(404, new
                {
                    status = "Города в стране с заданным идентификатором не существует"
                });
            }

            return StatusCode(200, new 
            { 
                status = "Информация о городе была успешно сформирована", 
                data = _dict.Places.GetCity(city_id) 
            });
        }

        /// <summary>
        /// Получить список городов, определённых в системе
        /// </summary>
        [HttpGet("Cities")]
        public IActionResult GetCities()
        {
            var cities = _dict.Places.GetCities();
            return cities.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список городов был успешно сформирован", 
                    data = cities 
                }) :
                StatusCode(404, new 
                { 
                    status = "Список городов пуст" 
                });
        }

        /// <summary>
        /// Получить список городов по идентификатору региона
        /// </summary>
        /// <param name="region_id">Идентификатор региона</param>
        [HttpGet("Regions/{region_id:int}/Cities")]
        public IActionResult GetCitiesByRegion(int region_id)
        {
            if (!_dict.Places.IsRegionExist(region_id))
            {
                return StatusCode(404, new
                {
                    status = "Региона с заданным идентификатором не существует"
                });
            }

            var cities = _dict.Places.GetCitiesByRegion(region_id);
            return cities.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список городов был успешно сформирован", 
                    data = cities 
                }) :
                StatusCode(404, new 
                { 
                    status = "Список городов для заданного региона пуст" 
                });
        }

        /// <summary>
        /// Получить список городов по идентификатору страны
        /// </summary>
        /// <param name="country_id">Идентификатор страны</param>
        [HttpGet("Countries/{country_id:int}/Cities")]
        public IActionResult GetCitiesByCountry(int country_id)
        {
            if (!_dict.Places.IsCountryExist(country_id))
            {
                return StatusCode(404, new
                {
                    status = "Страны с заданным идентификатором не существует"
                });
            }

            var cities = _dict.Places.GetCitiesByCountry(country_id);
            return cities.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список городов был успешно сформирован", 
                    data = cities 
                }) :
                StatusCode(404, new 
                { 
                    status = "Список городов для заданной страны пуст" 
                });
        }



        /// <summary>
        /// Получить информацию о регионе
        /// </summary>
        /// <param name="region_id">Идентификатор региона</param>
        [HttpGet("Regions/{region_id:int}")]
        public IActionResult GetRegion(int region_id) => _dict.Places.IsRegionExist(region_id) ?
            StatusCode(200, new 
            { 
                status = "Информация о регионе была успешно сформирована", 
                data = _dict.Places.GetRegion(region_id) 
            }) :
            StatusCode(404, new 
            { 
                status = "Региона с заданным идентификатором не существует" 
            });

        /// <summary>
        /// Получить информацию о регионе
        /// </summary>
        /// <param name="region_id">Идентификатор региона</param>
        /// <param name="country_id">Идентификатор страны</param>
        [HttpGet("Countries/{country_id:int}/Regions/{region_id:int}")]
        public IActionResult GetRegionByCountry(int region_id, int country_id)
        {
            if (!_dict.Places.IsCountryExist(country_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Страны с заданным идентификатором не существует" 
                });
            }
            if (!_dict.Places.IsRegionExist(region_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Региона с заданным идентификатором не существует" 
                });
            }
            if (!_dict.Places.IsRegionExistInCountry(region_id, country_id))
            {
                return StatusCode(404, new
                {
                    status = "Региона в стране с заданным идентификатором не существует"
                });
            }

            return StatusCode(200, new 
            { 
                status = "Информация о регионе была успешно сформирована", 
                data = _dict.Places.GetRegion(region_id) 
            });
        }

        /// <summary>
        /// Получить список регионов, определённых в системе
        /// </summary>
        [HttpGet("Regions/Get")]
        public IActionResult GetRegions()
        {
            var regions = _dict.Places.GetRegions();
            return regions.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список регионов был успешно сформирован", 
                    data = regions 
                }) :
                StatusCode(404, new 
                { 
                    status = "Список регионов пуст" 
                });
        }

        /// <summary>
        /// Получить список регионов по идентификатору страны
        /// </summary>
        /// <param name="country_id">Идентификатор страны</param>
        [HttpGet("Countries/{country_id:int}/Regions")]
        public IActionResult GetRegionsByCountry(int country_id)
        {
            if (!_dict.Places.IsCountryExist(country_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Страны с заданным идентификатором не существует" 
                });
            }

            var regions = _dict.Places.GetRegionsByCountry(country_id);
            return regions.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список регионов был успешно сформирован", 
                    data = regions 
                }) :
                StatusCode(404, new 
                { 
                    status = "Региона в стране с заданным идентификатором не существует" 
                });
        }



        /// <summary>
        /// Получить информацию о стране по её идентификатору
        /// </summary>
        /// <param name="country_id">Идентификатор страны</param>
        [HttpGet("Countries/{country_id:int}")]
        public IActionResult GetCountry(int country_id) => _dict.Places.IsCountryExist(country_id) ?
            StatusCode(200, new 
            { 
                status = "Информация о стране была успешно сформирована", 
                data = _dict.Places.GetCountry(country_id) 
            }) :
            StatusCode(404, new 
            { 
                status = "Страны с заданным идентификатором не существует" 
            });

        /// <summary>
        /// Получить список стран, определённых в системе
        /// </summary>
        [HttpGet("Countries")]
        public IActionResult GetCountries()
        {
            var countries = _dict.Places.GetCountries();
            return countries.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список стран был успешно сформирован", 
                    data = countries 
                }) :
                StatusCode(404, new 
                { 
                    status = "Список стран пуст" 
                });
        }

        #endregion



        #region Семейные положения пользователей

        /// <summary>
        /// Получить информацию о семейном положении по его идентификатору
        /// </summary>
        /// <param name="status_id">Идентификатор статуса</param>
        [HttpGet("FamilyStatuses/{status_id:int}")]
        public IActionResult GetFamilyStatus(int status_id) => _dict.Families.IsStatusExist(status_id) ?
            StatusCode(200, new 
            {
                status = "Информация о семейном положении была успешно сформирована", 
                data = _dict.Families.GetStatus(status_id) 
            }) :
            StatusCode(404, new 
            { 
                status = "Семейного положения с заданным идентификатором не существует" 
            });

        /// <summary>
        /// Получить список семейных положений
        /// </summary>
        [HttpGet("FamilyStatuses")]
        public IActionResult GetFamilyStatuses()
        {
            var statuses = _dict.Families.GetStatuses();
            return statuses.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список семейных положений был успешно сформирован", 
                    data = statuses 
                }) :
                StatusCode(404, new 
                { 
                    status = "Список семейных положений пуст" 
                });
        }

        #endregion



    }
}