using database.context.Models;
namespace database.context.Repos
{
    /// <summary>
    /// Взаимодействие с пользователем в системе
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Добавить нового пользователя в систему
        /// </summary>
        /// <param name="user">Информация о пользователе</param>
        public void Add(UserModel user);

        /// <summary>
        /// Получение информации о пользователе по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public UserModel? GetByID(int id);

        /// <summary>
        /// Получение информации о пользователе по его почте (логину)
        /// </summary>
        /// <param name="email">Почта (логин)</param>
        public UserModel? GetByEmail(string email);

        /// <summary>
        /// Получение информации о пользователе по его почте (логину) и паролю
        /// </summary>
        /// <param name="email">Почта (логин)</param>
        /// <param name="password">Пароль</param>
        public UserModel? GetByEmailAndPassword(string email, string password);

        /// <summary>
        /// Удалить пользователя из системы
        /// </summary>
        /// <param name="user">Информация о пользователе</param>
        public void Delete(UserModel user);
    }
}