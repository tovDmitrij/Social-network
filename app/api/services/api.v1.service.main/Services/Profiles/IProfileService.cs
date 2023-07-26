using db.v1.context.main.DTOs.Profiles;

namespace api.v1.service.main.Services.Profiles
{
    public interface IProfileService
    {
        public ProfileBaseInfoDTO GetProfileBaseInfo(string accessToken);
        public void SetCity(string accessToken, int cityID);
        public void SetFamilyStatus(string accessToken, int familyStatusID);
    }
}