using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace api.v1.service.main.Helpers.JWT
{
    public sealed class JWTHelper : IJWTHelper
    {
        public int GetUserID(string token)
        {
            var claims = GetClaims(token);
            return Convert.ToInt32(claims.First(x => x.Type == ClaimTypes.Name).Value);
        }

        private IEnumerable<Claim> GetClaims(string token) => new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
    }
}