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
    }
}