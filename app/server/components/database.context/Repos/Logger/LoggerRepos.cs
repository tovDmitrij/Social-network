using database.context.Contexts;
using database.context.Models.Data;
namespace database.context.Repos.Logger
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