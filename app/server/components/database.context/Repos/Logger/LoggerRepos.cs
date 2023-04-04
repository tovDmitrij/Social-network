using database.context.Contexts;
namespace database.context.Repos.Logger
{
    public sealed class LoggerRepos : ILoggerRepos
    {
        private readonly LoggerContext _db;
        public LoggerRepos(LoggerContext db) => _db = db;

        public void Log(string message, string source, string stack_trace)
        {
            _db.TableLogs.Add(new(
                message, 
                source, 
                stack_trace));
            _db.SaveChanges();
        }
    }
}