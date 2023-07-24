using api.v1.service.main.DTOs.Users;
using api.v1.service.main.Exceptions;
using api.v1.service.main.Helpers;
using db.v1.context.main.Repositories.Dictionary;
using db.v1.context.main.Repositories.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace api.v1.service.main.Services.Users
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepos _users;
        private readonly IDictionaryRepos _dict;
        private readonly IConfiguration _cfg;

        public UserService(IUserRepos users, IDictionaryRepos dict, IConfiguration cfg)
        {
            _users = users;
            _dict = dict;
            _cfg = cfg;
        }
        
        public void SignUp(UserSignUpDTO body)
        {
            var hashedPass = GetHashedPassword(body.email, body.password);

            if (_users.IsEmailBusy(body.email)) 
            { 
                throw new ValidationException("Почта уже занята другим пользователем"); 
            }

            var defaultProfileURL = Convert.ToBase64String(Encoding.UTF8.GetBytes(body.email))[..^2];
            var roleID = _dict.GetAppUserRole("default").ID;
            var regDateTimestamp = GetCurrentTimestamp();

            _users.SignUp(body.email, hashedPass, regDateTimestamp, roleID, body.surname, body.name, defaultProfileURL);
        }

        public TokenDTO SignIn(UserSignInDTO body)
        {
            var hashedPass = GetHashedPassword(body.email, body.password);

            if (!_users.IsUserExist(body.email, hashedPass))
            {
                throw new ValidationException("Пользователя с заданным логином и паролем не существует");
            }

            var refreshToken = CreateRefreshToken(body.email);

            var userID = _users.GetUserByRefreshToken(refreshToken)!.ID;

            var accessTokenStr = CreateAccessToken(userID);

            return new(accessTokenStr, refreshToken);
        }

        public string UpdateAccessToken(string refreshToken)
        {
            var utcnow = GetCurrentTimestamp();
            if (_users.IsRefreshTokenExpired(refreshToken, utcnow))
            {
                throw new UnauthorizedException("Токен просрочен или повреждён. Пожалуйста, пройдите заново процесс авторизации");
            }

            var userID = _users.GetUserByRefreshToken(refreshToken)!.ID;

            return CreateAccessToken(userID);
        }

        private string CreateAccessToken(int userID)
        {
            var claims = new List<Claim> { new(ClaimTypes.Name, userID.ToString()) };
            var credentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_cfg["JWT:SecretKey"]!)),
                    SecurityAlgorithms.HmacSha512Signature);

            var accessToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(accessToken);
        }

        private string CreateRefreshToken(string email)
        {
            var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            var createDate = GetCurrentTimestamp();
            var expireDate = createDate + Convert.ToInt32(_cfg["JWT:ExpireDate"]!);
            _users.SignIn(email, refreshToken, createDate, expireDate);

            return refreshToken;
        }

        private string GetHashedPassword(string email, string password) => HashDataHelper.HashPasswordSHA512(email, password);

        private decimal GetCurrentTimestamp() => (decimal)DateTime.UtcNow.Subtract(DateTime.Parse("1970-01-01")).TotalSeconds;
    }
}