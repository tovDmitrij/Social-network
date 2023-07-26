using db.v1.context.main.Entities.Users;

namespace db.v1.context.main.Repositories.Users
{
    public interface IUserRepos
    {
        public void SignUp(string email, string hashedPass, decimal regDate, int roleID, string surname, string name, string profileURL);
        public void SignIn(string email, string refreshToken, decimal createDate, decimal expireDate);
        public bool IsEmailBusy(string email);
        public bool IsUserExist(Guid userID);
        public bool IsUserExist(string email, string hashedPass);
        public bool IsRefreshTokenExpired(string refreshToken, decimal utcnow);
        public UserEntity? GetUserByRefreshToken(string refreshToken);
    }
}