using db.v1.context.profiles.Models.BaseInfo;
using db.v1.context.profiles.Models.Careers;
using db.v1.context.profiles.Models.Languages;
using db.v1.context.profiles.Models.LifePositions;
using db.v1.context.profiles.Models.MilitaryServices;
namespace db.v1.context.profiles.Repos
{
    /// <summary>
    /// Взаимодействие с профилем пользователей
    /// </summary>
    public interface IProfileRepos
    {



        #region Основная информация

        /// <summary>
        /// Получить базовую информацию о профиле пользователя
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
        public void ChangeAvatar(int userID, string avatar);

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



        #region Карьера

        /// <summary>
        /// Добавить новую карьеру в профиль пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="company">Наименование компании</param>
        /// <param name="job">Наименование должности</param>
        /// <param name="dateFrom">Дата начала карьеры</param>
        /// <param name="dateTo">Дата окончания</param>
        public void AddCarrer(int userID, int cityID, string company, string? job, DateTime? dateFrom, DateTime? dateTo);

        /// <summary>
        /// Обновить информацию о карьере
        /// </summary>
        /// <param name="carrerID">Идентификатор карьеры</param>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="company">Наименование компании</param>
        /// <param name="job">Наименование должности</param>
        /// <param name="dateFrom">Дата начала карьеры</param>
        /// <param name="dateTo">Дата окончания</param>
        public void UpdateCarrer(int carrerID, int cityID, string company, string? job, DateTime? dateFrom, DateTime? dateTo);
        
        /// <summary>
        /// Удалить карьеру из профиля пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="carrerID">Идентификатор карьеры</param>
        public void RemoveCarrer(int userID, int carrerID);

        /// <summary>
        /// Метод, проверяющий наличие карьеры в профиле пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="carrerID">Идентификатор карьеры</param>
        public bool IsCarrerAdded(int userID, int carrerID);

        /// <summary>
        /// Метод, проверяющий наличие карьеры в профиле пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="company">Наименование компании</param>
        /// <param name="job">Наименование должности</param>
        /// <param name="dateFrom">Дата начала карьеры</param>
        /// <param name="dateTo">Дата окончания</param>
        public bool IsCarrerAdded(int userID, int cityID, string company, string? job, DateTime? dateFrom, DateTime? dateTo);

        /// <summary>
        /// Получить список карьер пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        public IEnumerable<ProfileCarrerViewModel>? GetCarrers(int userID);

        #endregion



        #region Военная служба

        /// <summary>
        /// Добавить ВС в профиль пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="countryID">Идентификатор страны</param>
        /// <param name="militaryUnit">Наименование военной части</param>
        /// <param name="dateFrom">Дата начала ВС</param>
        /// <param name="dateTo">Дата конца ВС</param>
        public void AddMilitaryService(int userID, int countryID, string militaryUnit, DateTime? dateFrom, DateTime? dateTo);

        /// <summary>
        /// Обновить информацию о ВС пользователя
        /// </summary>
        /// <param name="serviceID">Идентификатор ВС</param>
        /// <param name="countryID">Идентификатор страны</param>
        /// <param name="militaryUnit">Наименование военной части</param>
        /// <param name="dateFrom">Дата начала ВС</param>
        /// <param name="dateTo">Дата конца ВС</param>
        public void UpdateMilitaryService(int serviceID, int countryID, string militaryUnit, DateTime? dateFrom, DateTime? dateTo);
        
        /// <summary>
        /// Удалить ВС у пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="serviceID">Идентификатор военной службы</param>
        public void RemoveMilitaryService(int userID, int serviceID);

        /// <summary>
        /// Метод, проверяющий наличие ВС у пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="serviceID">Идентификатор военной службы</param>
        public bool IsMilitaryServiceAdded(int userID, int serviceID);

        /// <summary>
        /// Метод, проверяющий наличие ВС у пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="countryID">Идентификатор страны</param>
        /// <param name="militaryUnit">Наименование военной части</param>
        /// <param name="dateFrom">Дата начала ВС</param>
        /// <param name="dateTo">Дата конца ВС</param>
        public bool IsMilitaryServiceAdded(int userID, int countryID, string militaryUnit, DateTime? dateFrom, DateTime? dateTo);

        /// <summary>
        /// Получить список военных служб пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        public IEnumerable<ProfileMilitaryServiceViewModel>? GetMilitaryServices(int userID);

        #endregion



    }
}