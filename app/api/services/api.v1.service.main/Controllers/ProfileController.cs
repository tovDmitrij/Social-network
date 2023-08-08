using api.v1.service.main.Services.Profiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.v1.service.main.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/profiles")]
    public sealed class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService) => _profileService = profileService;



        [HttpGet("auth/base")]
        public IActionResult GetAuthProfileBaseInfo() 
        {
            var accessToken = GetAccessToken();
            return Ok(_profileService.GetProfileBaseInfo(accessToken));
        }

        [HttpPost("auth/city")]
        public IActionResult SetCity(int cityID)
        {
            var accessToken = GetAccessToken();
            _profileService.SetCity(accessToken, cityID);
            return Ok();
        }

        [HttpPost("auth/familyStatus")]
        public IActionResult SetFamilyStatus(int familyStatusID)
        {
            var accessToken = GetAccessToken();
            _profileService.SetFamilyStatus(accessToken, familyStatusID);
            return Ok();
        }

        //TODO 

        [HttpPost("auth/surname")]
        public IActionResult SetSurname(string surname)
        {
            return Ok();
        }

        [HttpPost("auth/name")]
        public IActionResult SetName(string name)
        {
            return Ok();
        }

        [HttpPost("auth/status")]
        public IActionResult SetStatus(string status)
        {
            return Ok();
        }

        [HttpPost("auth/url")]
        public IActionResult SetProfileURL(string profileURL)
        {
            return Ok();
        }

        [HttpPost("auth/birthdate")]
        public IActionResult SetBirthdate(decimal  birthdate)
        {
            return Ok();
        }



        [NonAction]
        private string GetAccessToken() => 
            HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
    }
}