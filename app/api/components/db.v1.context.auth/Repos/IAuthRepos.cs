using db.v1.context.auth.Models;
namespace db.v1.context.auth.Repos
{
    /// <summary>
    /// Взаимодействие с аккаунтом пользователей
    /// </summary>
    public interface IAuthRepos
    {
        /// <summary>
        /// Метод, проверяющий зарегистрирован ли аккаунт в системе
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns></returns>
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
        public void Add(string email, string password);

        /// <summary>
        /// Получить базовую информацию о пользователе по его почте и паролю
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        public UserViewModel? GetAccountInfo(string email, string password);
    }
}