using database.context.Models.Auth;
namespace database.context.Repos.User
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
        /// Метод, проверяющий занята ли почта пользователя кем-то в системе
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        public bool IsEmailBusy(string email);

        /// <summary>
        /// Добавить нового пользователя в систему
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="surname">Фамилия пользователя</param>
        /// <param name="name">Имя пользователя</param>
        /// <param name="patronymic">Отчество пользователя</param>
        public void Add(string email, string password, string surname, string name, string? patronymic);

        /// <summary>
        /// Получить базовую информацию о пользователе по его почте и паролю
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        public UserAuthModel? GetAccountInfo(string email, string password);
    }
}