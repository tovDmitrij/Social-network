using db.v1.context.main.DTOs.Profiles;

namespace db.v1.context.main.Repositories.Profiles
{
    public interface IProfileRepos
    {
        public ProfileBaseInfoDTO GetProfileBaseInfo(Guid userID);
    }
}