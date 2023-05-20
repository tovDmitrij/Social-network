using db.v1.context.dictionary.Models;
namespace db.v1.context.dictionary.Repos.Languages
{
    /// <summary>
    /// Взаимодействие с таблицей языков платформы
    /// </summary>
    internal sealed class LanguageRepos : ILanguageRepos
    {
        /// <summary>
        /// База данных словаря
        /// </summary>
        private readonly DictionaryContext _db;
        public LanguageRepos(DictionaryContext db) => _db = db;

        public bool IsLanguageExist(int langID) => _db.TableLanguages
            .Any(lang => lang.ID == langID);

        public LanguageModel? GetLanguage(int langID) => _db.TableLanguages
            .FirstOrDefault(lang => lang.ID == langID);

        public IEnumerable<LanguageModel>? GetLanguages() => _db.TableLanguages
            .Select(lang => lang);
    }
}