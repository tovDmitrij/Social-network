using db.v1.context.profiles.Contexts.Interfaces;
using db.v1.context.profiles.Models.Dictionary;
namespace db.v1.context.profiles.Repos.Languages
{
    /// <summary>
    /// Взаимодействие с таблицей языков платформы
    /// </summary>
    internal sealed class LanguageRepos : ILanguageRepos
    {
        /// <summary>
        /// База данных профилей пользователей
        /// </summary>
        private readonly ILanguageContext _db;

        public LanguageRepos(ILanguageContext db) => _db = db;

        public bool IsLanguageExist(int langID) => _db.TableLanguages
            .Any(lang => lang.ID == langID);

        public LanguageModel? GetLanguage(int langID) => _db.TableLanguages
            .FirstOrDefault(lang => lang.ID == langID);

        public IEnumerable<LanguageModel>? GetLanguages() => _db.TableLanguages
            .Select(lang => lang);
    }
}