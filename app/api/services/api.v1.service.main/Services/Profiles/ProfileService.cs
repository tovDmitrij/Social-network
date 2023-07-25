using api.v1.service.main.Helpers.JWT;
using db.v1.context.main.DTOs.Profiles;
using db.v1.context.main.Repositories.Profiles;

namespace api.v1.service.main.Services.Profiles
{
    public sealed class ProfileService : IProfileService
    {
        private readonly IProfileRepos _profileRepos;
        private readonly IJWTHelper _jwtHelper;

        public ProfileService(IProfileRepos profileRepos, IJWTHelper jwtHelper)
        {
            _profileRepos = profileRepos;
            _jwtHelper = jwtHelper;
        }

        public ProfileBaseInfoDTO GetProfileBaseInfo(string accessToken)
        {
            var userID = _jwtHelper.GetUserID(accessToken);

            return _profileRepos.GetProfileBaseInfo(userID);
        }
    }
}