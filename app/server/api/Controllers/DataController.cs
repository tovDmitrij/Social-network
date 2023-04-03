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
    public sealed class DataController: ControllerBase
    {
        private readonly ILanguageRepos _language;
        private readonly ILifePositionsRepos _lifePositions;
        private readonly ICityRepos _city;
        public DataController(ILanguageRepos language, ILifePositionsRepos lifePositions, ICityRepos city)
        {
            _language = language;
            _lifePositions = lifePositions;
            _city = city;
        }



        #region Языки

        /// <summary>
        /// Получить информацию о языке по его идентификатору
        /// </summary>
        /// <param name="langID">Идентификатор языка</param>
        [HttpGet("Languages/Get/{langID:int}")]
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
        [HttpGet("LifePositions/Get/Position/{posID:int}")]
        public IActionResult GetLifePosition(int posID)
        {
            switch (_lifePositions.IsLifePositionExist(posID))
            {
                case true:
                    return StatusCode(200, new
                    {
                        status = "Информация о жизненной позиции была успешно сформированна",
                        data = _lifePositions.GetLifePosition(posID)
                    });

                case false:
                    return StatusCode(404, new { status = "Жизненной позиции с заданным идентификатором не существует" });
            }
        }

        /// <summary>
        /// Получить список жизненных позиций, определённых в системе, по их типу
        /// </summary>
        /// <param name="typeID">Идентификатор типа жизненных позиций</param>
        /// <returns></returns>
        [HttpGet("LifePositions/Get/Type/{typeID:int}")]
        public IActionResult GetLifePositionsByType(int typeID)
        {
            if (!_lifePositions.IsLifePositionTypeExist(typeID))
            {
                return StatusCode(404, new { status = "Тип жизненной позиции с заданным идентификатором не существует в системе" });
            }

            var positions = _lifePositions.GetLifePositions(typeID);
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
            var positions = _lifePositions.GetLifePositions();

            return positions.Any() ?
                StatusCode(200, new
                {
                    status = "Список жизненных позиций был успешно сформирован",
                    data = positions
                }) :
                StatusCode(404, new { status = "Список жизненных позиций пуст" });
        }

        #endregion



        #region Города

        /// <summary>
        /// Получить список городов, определённых в системе
        /// </summary>
        [HttpGet("Cities/Get")]
        public IActionResult GetCities()
        {
            var cities = _city.

            return cities.Any() ? 
                StatusCode(200, new
                {
                    status = "Список городов был успешно сформирован",
                    data = cities
                }) :
                StatusCode(404, new { status = "Список городов пуст" });
        }

        #endregion



    }
}