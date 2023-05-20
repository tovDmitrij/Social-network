using db.v1.context.auth.Models;
namespace db.v1.context.auth.Repos
{
    /// <summary>
    /// Взаимодействие с аккаунтом пользователей
    /// </summary>
    public interface IAuthRepos
    {



        #region Аккаунты

        /// <summary>
        /// Метод, проверяющий зарегистрирован ли аккаунт в системе
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        public bool IsAccountExist(string email, string password);

        /// <summary>
        /// Метод, проверяющий занятость кем-либо указанной почты
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        public bool IsEmailBusy(string email);

        /// <summary>
        /// Добавить нового пользователя в систему
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        public int AddAccount(string email, string password);

        /// <summary>
        /// Получить базовую информацию о пользователе
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        public UserViewModel? GetAccountInfo(string email, string password);

        /// <summary>
        /// Получить базовую информацию о пользователе
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        public UserViewModel? GetAccountInfo(int id);

        #endregion



        #region Токены

        /// <summary>
        /// Метод, проверяющий существование refresh-токена
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="token">Refresh-токен</param>
        public bool IsTokenExist(int userID, string token);

        /// <summary>
        /// Метод, проверяющий актуальность refresh-токена
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="token">Refresh-токен</param>
        public bool IsTokenExpired(int userID, string token);

        /// <summary>
        /// Добавить refresh-токен в БД
        /// </summary>
        /// <param name="token">Refresh-токен</param>
        public void AddToken(UserTokenModel token);

        /// <summary>
        /// Получить информацию о refresh-токене
        /// </summary>
        /// <param name="token">Refresh-токен</param>
        public UserTokenModel? GetToken(string token);

        #endregion



    }
}