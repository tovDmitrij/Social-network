using database.context.Models.Auth;
namespace database.context.Repos.User
{
    /// <summary>
    /// Взаимодействие с аккаунтом пользователей
    /// </summary>
    public interface IAuthRepos
    {
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
        /// Получить информацию о пользователе по его почте
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <returns>Информация о пользователе в виде JSON</returns>
        public UserAuthModel? GetByEmail(string email);

        /// <summary>
        /// Получить информацию о пользователе по его почте и паролю
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Информация о пользователе в виде JSON</returns>
        public UserAuthModel? GetByEmailAndPassword(string email, string password);
    }
}