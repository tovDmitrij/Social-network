using db.v1.context.dictionary.Models;
namespace db.v1.context.dictionary.Repos.Languages
{
    /// <summary>
    /// Взаимодействие с таблицей языков платформы
    /// </summary>
    public interface ILanguageRepos
    {
        /// <summary>
        /// Метод, проверяющий существование языка
        /// </summary>
        /// <param name="langID">Идентификатор языка</param>
        public bool IsLanguageExist(int langID);

        /// <summary>
        /// Получить информацию о языке
        /// </summary>
        /// <param name="langID">Идентификатор языка</param>
        public LanguageModel? GetLanguage(int langID);

        /// <summary>
        /// Получить список языков
        /// </summary>
        public IEnumerable<LanguageModel>? GetLanguages();
    }
}