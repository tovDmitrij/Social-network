using database.context.Models.Misc;
namespace database.context.Repos.Languages
{
    public sealed class LanguageRepos : BaseRepos, ILanguageRepos
    {
        public LanguageRepos(DataContext db) : base(db) { }

        public bool IsLanguageExist(int langID) => _db.TableLanguages
            .Any(language => language.ID == langID);

        public LanguageModel? GetLanguage(int langID) => _db.TableLanguages
            .Single(language => language.ID == langID);

        public IEnumerable<LanguageModel>? GetLanguages() => _db.TableLanguages
            .Select(language => language);
    }
}