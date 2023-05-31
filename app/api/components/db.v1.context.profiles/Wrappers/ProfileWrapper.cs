using db.v1.context.profiles.Contexts;
using db.v1.context.profiles.Repos.FamilyStatuses;
using db.v1.context.profiles.Repos.Languages;
using db.v1.context.profiles.Repos.LifePositions;
using db.v1.context.profiles.Repos.Places;
using db.v1.context.profiles.Repos.Profiles;
namespace db.v1.context.profiles.Wrappers
{
    /// <summary>
    /// Взаимодействие с БД профилей пользователей
    /// </summary>
    public sealed class ProfileWrapper : IProfileWrapper
    {
        private readonly IProfileRepos _profiles;
        private readonly IFamilyStatusRepos _families;
        private readonly ILanguageRepos _langs;
        private readonly ILifePositionRepos _pos;
        private readonly IPlaceRepos _places;

        public IProfileRepos Profiles => _profiles;
        public IFamilyStatusRepos Families => _families;
        public ILanguageRepos Langs => _langs;
        public ILifePositionRepos Positions => _pos;
        public IPlaceRepos Places => _places;

        public ProfileWrapper(ProfileContext db)
        {
            _profiles = new ProfileRepos(db);
            _families = new FamilyStatusRepos(db);
            _langs = new LanguageRepos(db);
            _pos = new LifePositionRepos(db);
            _places = new PlaceRepos(db);
        }
    }
}