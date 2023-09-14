using api.v1.service.main.Exceptions;
using api.v1.service.main.Helpers.JWT;
using db.v1.context.main.DTOs.Profiles;
using db.v1.context.main.Repositories.Dictionary;
using db.v1.context.main.Repositories.Profiles;
using db.v1.context.main.Repositories.Users;

namespace api.v1.service.main.Services.Profiles
{
    public sealed class ProfileService : IProfileService
    {
        private readonly IProfileRepos _profileRepos;
        private readonly IUserRepos _userRepos;
        private readonly IDictionaryRepos _dictRepos;
        private readonly IJWTHelper _jwtHelper;

        public ProfileService(IProfileRepos profileRepos, IUserRepos userRepos, IDictionaryRepos dictRepos, IJWTHelper jwtHelper)
        {
            _profileRepos = profileRepos;
            _userRepos = userRepos;
            _dictRepos = dictRepos;
            _jwtHelper = jwtHelper;
        }



        public ProfileBaseInfoDTO GetProfileBaseInfo(string accessToken)
        {
            var userID = GetAndCheckUserID(accessToken);
            return _profileRepos.GetProfileBaseInfo(userID);
        }

        public void SetCity(string accessToken, int cityID)
        {
            var userID = GetAndCheckUserID(accessToken);
            var city = _dictRepos.GetCity(cityID) ?? throw new BadRequestException("Города с заданным идентификатором не существует");

            _profileRepos.SetCity(userID, city.ID);
        }

        public void SetFamilyStatus(string accessToken, int familyStatusID)
        {
            var userID = GetAndCheckUserID(accessToken);
            var familyStatus = _dictRepos.GetFamilyStatus(familyStatusID) ?? throw new BadRequestException("Семейного положения с заданным идентификатором не существует");

            _profileRepos.SetFamilyStatus(userID, familyStatus.ID);
        }



        private Guid GetAndCheckUserID(string accessToken)
        {
            var userID = _jwtHelper.GetUserID(accessToken);
            if (!_userRepos.IsUserExist(userID))
            {
                throw new UnauthorizedException("Токен повреждён: пользователя с заданным идентификатором не существует");
            }
            return userID;
        }
    }
}