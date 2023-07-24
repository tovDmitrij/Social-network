using db.v1.context.main.Contexts.Main.Interfaces;
using db.v1.context.main.Entities.Users;

namespace db.v1.context.main.Repositories.Profiles
{
    public sealed class ProfileRepos : IProfileRepos
    {
        private readonly IUserContext _users;

        public ProfileRepos(IUserContext users)
        {
            _users = users ?? throw new ArgumentNullException(nameof(users));
        }

        public UserEntity GetProfileInfo(int userID) => _users.Users
            .First(x => x.ID == userID);
    }
}