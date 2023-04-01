using database.context.Models.Misc;
namespace database.context.Repos.Languages
{
    /// <summary>
    /// Взаимодействие с таблицей языков платформы
    /// </summary>
    public interface ILanguageRepos
    {
        /// <summary>
        /// Метод, проверяющий существования языка с заданным идентификатором
        /// </summary>
        /// <param name="id">Идентификатор языка</param>
        public bool IsLanguageExist(int id);

        /// <summary>
        /// Получить информацию о конкретном языке по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор языка</param>
        public LanguageModel? GetLanguageInfo(int id);

        /// <summary>
        /// Получить список языков
        /// </summary>
        public IEnumerable<LanguageModel> GetLanguages();
    }
}