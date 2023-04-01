using database.context.Models.Misc;
namespace database.context.Repos.Languages
{
    public sealed class LanguageRepos : BaseRepos, ILanguageRepos
    {
        public LanguageRepos(DataContext db) : base(db) { }

        public bool IsLanguageExist(int id) => _db.TableLanguages
            .Any(language => language.ID == id);

        public LanguageModel? GetLanguageInfo(int id) => _db.TableLanguages
            .FirstOrDefault(language => language.ID == id);

        public IEnumerable<LanguageModel> GetLanguages() => _db.TableLanguages
            .Select(language => language);
    }
}