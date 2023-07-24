using db.v1.context.main.Contexts.Main.Interfaces;
using db.v1.context.main.Entities.Users;

namespace db.v1.context.main.Repositories.Users
{
    public sealed class UserRepos : IUserRepos
    {
        private readonly IUserContext _users;

        public UserRepos(IUserContext users) => _users = users;

        public void SignUp(string email, string hashedPass, decimal regDate, int roleID, string surname, string name, string profileURL)
        {
            _users.Users.Add(new(roleID, email, hashedPass, regDate, surname, name, profileURL));
            _users.SaveChanges();
        }

        public void SignIn(string email, string refreshToken, decimal createDate, decimal expireDate)
        {
            var user = _users.Users.First(x => x.Email == email);
            user.Token = refreshToken;
            user.CreateDate = createDate;
            user.ExpireDate = expireDate;

            _users.Users.Update(user);
            _users.SaveChanges();
        }

        public bool IsUserExist(string email, string hashedPass) => _users.Users
            .Any(x => x.Email == email && x.Password == hashedPass);

        public bool IsEmailBusy(string email) => _users.Users
            .Any(x => x.Email == email);

        public bool IsRefreshTokenExpired(string refreshToken, decimal utcnow) => _users.Users
            .Any(x => x.Token == refreshToken && x.ExpireDate < utcnow);

        public UserEntity? GetUserByRefreshToken(string refreshToken) => _users.Users
            .FirstOrDefault(x => x.Token == refreshToken);
    }
}