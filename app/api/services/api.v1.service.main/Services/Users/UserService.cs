using api.v1.service.main.DTOs.Users;
using api.v1.service.main.Exceptions;
using api.v1.service.main.Helpers.Timestamps;
using api.v1.service.main.Helpers.Validators.Interfaces;
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
        private readonly IUserRepos _userRepos;
        private readonly IDictionaryRepos _dictRepos;
        private readonly IUserValidateHelper _validateHelper;
        private readonly ITimestampHelper _timestampHelper;
        private readonly IConfiguration _cfg;

        public UserService(IUserRepos userRepos, IDictionaryRepos dictRepos, IConfiguration cfg, 
                           ITimestampHelper timestampHelper, IUserValidateHelper validateHelper)
        {
            _userRepos = userRepos;
            _dictRepos = dictRepos;
            _cfg = cfg;
            _timestampHelper = timestampHelper;
            _validateHelper = validateHelper;
        }
        


        public void SignUp(UserSignUpDTO body)
        {
            _validateHelper.ValidateEmail(body.email);
            _validateHelper.ValidatePassword(body.password);
            _validateHelper.ValidateFullname($"{body.surname} {body.name}");
;
            var hashedPass = HashPasswordWithSaltSHA512(body.email, body.password);

            if (_userRepos.IsEmailBusy(body.email)) 
            { 
                throw new ValidationException("Почта уже занята другим пользователем"); 
            }


            var defaultProfileURL = CreateProfileDefaultURL(body.email);
            var roleID = _dictRepos.GetAppUserRole("default")!.ID;
            var regDateTimestamp = _timestampHelper.GetCurrentTimestamp();

            _userRepos.SignUp(body.email, hashedPass, regDateTimestamp, roleID, body.surname, body.name, defaultProfileURL);
        }

        public TokenDTO SignIn(UserSignInDTO body)
        {
            _validateHelper.ValidateEmail(body.email);
            _validateHelper.ValidatePassword(body.password);

            var hashedPass = HashPasswordWithSaltSHA512(body.email, body.password);

            if (!_userRepos.IsUserExist(body.email, hashedPass))
            {
                throw new ValidationException("Пользователя с заданным логином и паролем не существует");
            }

            var refreshToken = CreateRefreshToken(body.email);
            var userID = _userRepos.GetUserByRefreshToken(refreshToken)!.ID;
            var accessToken = CreateAccessToken(userID);

            return new(accessToken, refreshToken);
        }

        public string UpdateAccessToken(string refreshToken)
        {
            var utcnow = _timestampHelper.GetCurrentTimestamp();
            if (_userRepos.IsRefreshTokenExpired(refreshToken, utcnow))
            {
                throw new UnauthorizedException("Токен просрочен или повреждён. Пожалуйста, пройдите заново процесс авторизации");
            }

            var userID = _userRepos.GetUserByRefreshToken(refreshToken)!.ID;
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
            var createDate = _timestampHelper.GetCurrentTimestamp();
            var expireDate = createDate + Convert.ToInt32(_cfg["JWT:ExpireDate"]!);
            _userRepos.SignIn(email, refreshToken, createDate, expireDate);

            return refreshToken;
        }
        
        private string CreateProfileDefaultURL(string email) => Convert.ToBase64String(Encoding.UTF8.GetBytes(email))[..^2];

        private string HashPasswordWithSaltSHA512(string email, string password)
        {
            const string SALT = "salt_secret_key";
            var bytes = SHA512.HashData(Encoding.UTF8.GetBytes($"{SALT}{email}{password}"));
            var hashData = new StringBuilder();
            foreach (var @byte in bytes)
            {
                hashData.Append(@byte.ToString("x2"));
            }
            return hashData.ToString();
        }
    
    }
}