using database.context.Models.Profile;
using database.context.Models.Profile.Languages;
namespace database.context.Repos.Profile
{
    /// <summary>
    /// Взаимодействие с профилем пользователей
    /// </summary>
    public interface IProfileRepos
    {
        /// <summary>
        /// Получить базовую информацию о профиле пользователя по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        public UserBaseInfoModel? GetProfileBaseInfo(int id);



        #region Языки

        /// <summary>
        /// Получить информацию об языке по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор языка</param>
        public LanguageModel? GetLanguageInfo(int id);

        /// <summary>
        /// Добавить новый язык в профиль пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="languageID">Идентификатор языка</param>
        public void AddLanguage(int userID, int languageID);

        /// <summary>
        /// Метод, проверяющий добавлен ли язык в список языков пользователя
        /// </summary>        
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="languageID">Идентификатор языка</param>
        public bool IsLanguageAdded(int userID, int languageID);

        /// <summary>
        /// Получить список выбранных языков пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        public IEnumerable<ProfileLanguageModel>? GetLanguages(int userID);

        #endregion



    }
}