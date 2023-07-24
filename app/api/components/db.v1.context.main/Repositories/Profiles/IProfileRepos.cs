using db.v1.context.main.Entities.Users;

namespace db.v1.context.main.Repositories.Profiles
{
    public interface IProfileRepos
    {
        public UserEntity GetProfileInfo(int userID);
    }
}