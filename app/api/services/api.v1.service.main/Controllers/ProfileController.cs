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

        public ProfileController(IProfileService profiles) => _profileService = profiles;

        [HttpGet("authorized")]
        public IActionResult Index() => Ok(_profileService.GetProfileBaseInfo(HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1]));
    }
}