using db.v1.context.logs.Models;
namespace db.v1.context.logs.Repos
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