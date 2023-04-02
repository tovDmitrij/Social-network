using Microsoft.AspNetCore.Mvc;
using database.context.Repos.Languages;
using database.context.Repos.LifePositions;
namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class DataController: ControllerBase
    {
        private readonly ILanguageRepos _language;
        private readonly ILifePositionsRepos _lifePositions;

        public DataController(ILanguageRepos language, ILifePositionsRepos lifePositions)
        {
            _language = language;
            _lifePositions = lifePositions;
        }

        /// <summary>
        /// Получить список языков, определённых в системе
        /// </summary>
        [HttpGet("Languages/Get")]
        public IActionResult GetLanguages() => StatusCode(200, new
            {
                status = "Список языков платформы был успешно сформирован",
                data = _language.GetLanguages()
            });

        /// <summary>
        /// Получить список жизненных позиций, определённых в системе
        /// </summary>
        [HttpGet("LifePositions/Get")]
        public IActionResult GetLifePositions() => StatusCode(200, new 
            { 
                status = "Список жизненных позиций был успешно сформирован",
                data = _lifePositions.GetLifePositions()
            });
    }
}