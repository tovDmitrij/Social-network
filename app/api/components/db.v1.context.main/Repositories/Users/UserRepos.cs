using db.v1.context.main.Contexts.Main.Interfaces;
using db.v1.context.main.Entities.Users;

namespace db.v1.context.main.Repositories.Users
{
    public sealed class UserRepos : IUserRepos
    {
        private readonly IUserContext _db;

        public UserRepos(IUserContext users) => _db = users;

        public void SignUp(string email, string hashedPass, decimal regDate, int roleID, string surname, string name, string profileURL)
        {
            _db.Users.Add(new(roleID, email, hashedPass, regDate, surname, name, profileURL));
            _db.SaveChanges();
        }

        public void SignIn(string email, string refreshToken, decimal createDate, decimal expireDate)
        {
            var user = _db.Users.First(x => x.Email == email);
            user.Token = refreshToken;
            user.CreateDate = createDate;
            user.ExpireDate = expireDate;

            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public bool IsUserExist(Guid userID) => _db.Users
            .Any(x => x.UUID == userID);

        public bool IsUserExist(string email, string hashedPass) => _db.Users
            .Any(x => x.Email == email && x.Password == hashedPass);

        public bool IsEmailBusy(string email) => _db.Users
            .Any(x => x.Email == email);

        public bool IsRefreshTokenExpired(string refreshToken, decimal utcnow) => !_db.Users
            .Any(x => x.Token == refreshToken && x.ExpireDate < utcnow);

        public UserEntity? GetUserByRefreshToken(string refreshToken) => _db.Users
            .FirstOrDefault(x => x.Token == refreshToken);
    }
}