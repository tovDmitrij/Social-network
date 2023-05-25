using db.v1.context.logs.Models;
namespace db.v1.context.logs.Repos
{
    /// <summary>
    /// Взаимодействие с таблицей логов
    /// </summary>
    public sealed class LogRepos : ILogRepos
    {
        /// <summary>
        /// База данных логов
        /// </summary>
        private readonly LogContext _db;

        public LogRepos(LogContext db) => _db = db;

        public void Log(LogModel log)
        {
            _db.TableLogs.Add(log);
            _db.SaveChanges();
        }
    }
}