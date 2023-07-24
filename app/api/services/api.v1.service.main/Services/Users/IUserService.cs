using api.v1.service.main.DTOs.Users;

namespace api.v1.service.main.Services.Users
{
    public interface IUserService
    {
        public void SignUp(UserSignUpDTO body);

        public TokenDTO SignIn(UserSignInDTO body);

        public string UpdateAccessToken(string refreshToken);
    }
}