namespace database.context.logs.Repos
{
    public sealed class LoggerRepos : ILoggerRepos
    {
        private readonly LoggerContext _db;

        public LoggerRepos(LoggerContext db) => _db = db;

        public void Log(LogModel log)
        {
            _db.TableLogs.Add(log);
            _db.SaveChanges();
        }
    }
}