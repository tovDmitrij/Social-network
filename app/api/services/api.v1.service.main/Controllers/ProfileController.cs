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

        [HttpGet("authorized")]
        public IActionResult GetAuthProfileBaseInfo() 
        {
            var accessToken = GetAccessToken();
            return Ok(_profileService.GetProfileBaseInfo(accessToken));
        }

        [HttpPost("city")]
        public IActionResult SetCity(int cityID)
        {
            var accessToken = GetAccessToken();
            _profileService.SetCity(accessToken, cityID);
            return Ok();
        }

        [HttpPost("familyStatus")]
        public IActionResult SetFamilyStatus(int familyStatusID)
        {
            var accessToken = GetAccessToken();
            _profileService.SetFamilyStatus(accessToken, familyStatusID);
            return Ok();
        }

        [NonAction]
        private string GetAccessToken() => HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
    }
}