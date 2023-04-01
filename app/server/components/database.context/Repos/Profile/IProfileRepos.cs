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
        public ProfileBaseInfoModel? GetProfileBaseInfo(int id);

        /// <summary>
        /// Метод, проверяющий существует ли пользователь с заданным идентификатором
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        public bool IsUserExist(int id);



        #region Языки

        /// <summary>
        /// Добавить новый язык в профиль пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="languageID">Идентификатор языка</param>
        public void AddLanguage(int userID, int languageID);

        /// <summary>
        /// Удалить язык из профиля пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="languageID">Идентификатор языка</param>
        public void RemoveLanguage(int userID, int languageID);

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
        public IEnumerable<ProfileLanguageInfoModel>? GetLanguages(int userID);

        #endregion



    }
}