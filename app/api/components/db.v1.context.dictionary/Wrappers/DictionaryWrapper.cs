using db.v1.context.dictionary.Repos.FamilyStatuses;
using db.v1.context.dictionary.Repos.Languages;
using db.v1.context.dictionary.Repos.LifePositions;
using db.v1.context.dictionary.Repos.Places;
namespace db.v1.context.dictionary.Wrappers
{
    /// <summary>
    /// Взаимодействие с БД-справочником
    /// </summary>
    public sealed class DictionaryWrapper : IDictionaryWrapper
    {
        private readonly IFamilyStatusRepos _families;
        private readonly ILanguageRepos _langs;
        private readonly ILifePositionRepos _pos;
        private readonly IPlaceRepos _places;

        public IFamilyStatusRepos Families => _families;
        public ILanguageRepos Langs => _langs;
        public ILifePositionRepos Positions => _pos;
        public IPlaceRepos Places => _places;

        public DictionaryWrapper(DictionaryContext db)
        {
            _families = new FamilyStatusRepos(db);
            _langs = new LanguageRepos(db);
            _pos = new LifePositionRepos(db);
            _places = new PlaceRepos(db);
        }
    }
}