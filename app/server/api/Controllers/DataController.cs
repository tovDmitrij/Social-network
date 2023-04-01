using Microsoft.AspNetCore.Mvc;
using database.context.Repos.Languages;
namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class DataController: ControllerBase
    {
        private readonly ILanguageRepos _language;

        public DataController(ILanguageRepos language)
        {
            _language = language;
        }

        [HttpGet("Languages")]
        public IActionResult GetLanguages() => StatusCode(200,
            new
            {
                status = "Список языков платформы был успешно сформирован",
                languages = _language.GetLanguages()
            });
    }
}