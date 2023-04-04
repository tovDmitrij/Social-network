using database.context.main.Models.Profile.BaseInfo;
using database.context.main.Models.Profile.Languages;
using database.context.main.Models.Profile.LifePositions;
namespace database.context.main.Repos.Profile
{
    /// <summary>
    /// Взаимодействие с профилем пользователей
    /// </summary>
    public interface IProfileRepos
    {
        /// <summary>
        /// Метод, проверяющий существует ли пользователь с заданным идентификатором
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        public bool IsUserExist(int id);



        #region Основная информация

        /// <summary>
        /// Получить базовую информацию о профиле пользователя по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        public ProfileBaseInfoViewModel? GetProfileBaseInfo(int id);

        /// <summary>
        /// Изменить статус пользователя в профиле
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="status">Статус пользователя</param>
        public void ChangeStatus(int userID, string status);

        /// <summary>
        /// Изменить аватар пользователя в профиле
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="avatar">Аватарка пользователя</param>
        public void ChangeAvatar(int userID, byte[] avatar);

        /// <summary>
        /// Изменить родной город пользователя в профиле
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="cityID">Идентификатор города</param>
        public void ChangeCity(int userID, int cityID);

        /// <summary>
        /// Изменить семейное положение пользователя в профиле
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="statusID">Идентификатор семейного положения</param>
        public void ChangeFamilyStatus(int userID, int statusID);

        /// <summary>
        /// Изменить дату рождения пользователя в профиле
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="date">Дата рождения пользователя</param>
        public void ChangeBirthDate(int userID, DateTime date);

        /// <summary>
        /// Изменить ФИО пользователя в профиле
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="surname">Фамилия пользователя</param>
        /// <param name="name">Имя пользователя</param>
        /// <param name="patronymic">Отчество пользователя</param>
        public void ChangeFullname(int userID, string surname, string name, string patronymic);

        #endregion



        #region Языки

        /// <summary>
        /// Добавить новый язык в профиль пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="langID">Идентификатор языка</param>
        public void AddLanguage(int userID, int langID);

        /// <summary>
        /// Удалить язык из профиля пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="langID">Идентификатор языка</param>
        public void RemoveLanguage(int userID, int langID);

        /// <summary>
        /// Метод, проверяющий добавлен ли язык в список языков пользователя
        /// </summary>        
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="langID">Идентификатор языка</param>
        public bool IsLanguageAdded(int userID, int langID);

        /// <summary>
        /// Получить список выбранных языков пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        public IEnumerable<ProfileLanguageViewModel>? GetLanguages(int userID);

        #endregion



        #region Жизненные позиции

        /// <summary>
        /// Добавить новую жизненную позицию в профиль пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="posID">Идентификатор жизненной позиции</param>
        public void AddLifePosition(int userID, int posID);

        /// <summary>
        /// Удалить жизненную позицию из профиля пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="posID">Идентификатор жизненной позиции</param>
        public void RemoveLifePosition(int userID, int posID);

        /// <summary>
        /// Удалить категорию жизненной позиции из профиля пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="typeID">Идентификатор типа жизненной позиции</param>
        public void RemoveLifePositionType(int userID, int typeID);

        /// <summary>
        /// Метод, проверяющий наличие заданного типа жизненной позиции в профиле пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="typeID">Идентификатор типа жизненной позиции</param>
        public bool IsPositionTypeAdded(int userID, int typeID);

        /// <summary>
        /// Метод, проверяющий наличие заданной жизненной позиции в профиле пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="posID">Идентификатор жизненной позиции</param>
        /// <returns></returns>
        public bool IsPositionAdded(int userID, int posID);

        /// <summary>
        /// Получить список жизненных позиций пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        public IEnumerable<ProfileLifePositionViewModel>? GetLifePositions(int userID);

        #endregion



    }
}