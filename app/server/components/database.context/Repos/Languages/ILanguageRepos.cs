using database.context.Models.Misc;
namespace database.context.Repos.Languages
{
    /// <summary>
    /// Взаимодействие с таблицей языков платформы
    /// </summary>
    public interface ILanguageRepos
    {
        /// <summary>
        /// Метод, проверяющий существование языка с заданным идентификатором
        /// </summary>
        /// <param name="langID">Идентификатор языка</param>
        public bool IsLanguageExist(int langID);

        /// <summary>
        /// Получить язык, определённый в системе, по его идентификатору
        /// </summary>
        /// <param name="langID">Идентификатор языка</param>
        public LanguageModel? GetLanguage(int langID);

        /// <summary>
        /// Получить список языков, определённых в системе
        /// </summary>
        public IEnumerable<LanguageModel>? GetLanguages();
    }
}