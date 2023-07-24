using db.v1.context.main.Repositories.Profiles;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace api.v1.service.main.Controllers
{
    [ApiController]
    [Route("api/v1/profiles")]
    [Authorize]
    public sealed class ProfileController : ControllerBase
    {
        private readonly IProfileRepos _db;

        public ProfileController(IProfileRepos db) { _db = db; }

        [HttpGet]
        public IActionResult Index()
        {
            var accessToken = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];
            IEnumerable<Claim> claims = GetClaims(accessToken);
            int userID = Convert.ToInt32(claims.First(id => id.Type == ClaimTypes.Name).Value);
            

            var z = _db.GetProfileInfo(userID);
            return Ok(z);
        }

        [NonAction]
        public IEnumerable<Claim> GetClaims(string token) => new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
    }
}