using database.context.Models.Data;
namespace database.context.Repos.Logger
{
    /// <summary>
    /// Взаимодействие с таблицей логов
    /// </summary>
    public interface ILoggerRepos
    {
        /// <summary>
        /// Отправить новый отчёт об ошибке в базу данных
        /// </summary>
        /// <param name="log">Сообщение об ошибке</param>
        public void Log(LogModel log);
    }
}