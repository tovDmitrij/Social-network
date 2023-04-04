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
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="source">Наименование объекта, которое вызвало исключение</param>
        /// <param name="stack_trace">Строковое представление стека вызовов, которые привели к возникновению исключения</param>
        public void Log(string message, string source, string stack_trace);
    }
}