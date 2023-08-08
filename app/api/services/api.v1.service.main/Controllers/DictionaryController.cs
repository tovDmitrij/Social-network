using api.v1.service.main.Services.Dictionary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.v1.service.main.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/dict")]
    public class DictionaryController : ControllerBase
    {
        private readonly IDictionaryService _dictService;

        public DictionaryController(IDictionaryService dictService) => _dictService = dictService;



        [HttpGet("familyStatuses")]
        public IActionResult GetFamilyStatuses() => 
            Ok(_dictService.GetFamilyStatuses());

        [HttpGet("countries")]
        public IActionResult GetCountries() => 
            Ok(_dictService.GetCountries());

        [HttpGet("regions")]
        public IActionResult GetRegions() => 
            Ok(_dictService.GetRegions());

        [HttpGet("cities")]
        public IActionResult GetCities() => 
            Ok(_dictService.GetCities());
    }
}