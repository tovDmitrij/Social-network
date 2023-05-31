using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
namespace helpers.jwt
{
    /// <summary>
    /// Взаимодействие с JWT-токеном
    /// </summary>
    public class AuthToken: IAuthServiceToken, IProfileServiceToken
    {
        public int GetUserID(IHeaderDictionary header)
        {
            try
            {
                string token = header.Authorization.ToString().Split(' ')[1];
                IEnumerable<Claim> claims = GetClaims(token);
                int userID = Convert.ToInt32(claims.First(id => id.Type == ClaimTypes.Name).Value);
                return userID;
            }
            catch
            {
                return -1;
            }
        }

        public IEnumerable<Claim> GetClaims(string token) => new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
    }
}