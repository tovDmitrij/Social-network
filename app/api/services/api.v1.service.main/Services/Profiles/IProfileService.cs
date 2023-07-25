using db.v1.context.main.DTOs.Profiles;

namespace api.v1.service.main.Services.Profiles
{
    public interface IProfileService
    {
        public ProfileBaseInfoDTO GetProfileBaseInfo(string accessToken);
    }
}