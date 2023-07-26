using db.v1.context.main.Contexts.Main.Interfaces;
using db.v1.context.main.DTOs.Profiles;

namespace db.v1.context.main.Repositories.Profiles
{
    public sealed class ProfileRepos : IProfileRepos
    {
        private readonly IProfileContext _db;

        public ProfileRepos(IProfileContext db) => _db = db;

        public ProfileBaseInfoDTO GetProfileBaseInfo(Guid userID) => _db.Users
                .Where(x => x.UUID == userID)
                    .Select(x => new ProfileBaseInfoDTO(x.Surname, x.Name))
                        .First();

        public void SetCity(Guid userID, int cityID)
        {
            var user = _db.Users.First(x => x.UUID == userID);
            user.CityID = cityID;

            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public void SetFamilyStatus(Guid userID, int familyStatusID)
        {
            var user = _db.Users.First(x => x.UUID == userID);
            user.FamilyStatusID = familyStatusID;

            _db.Users.Update(user);
            _db.SaveChanges();
        }
    }
}