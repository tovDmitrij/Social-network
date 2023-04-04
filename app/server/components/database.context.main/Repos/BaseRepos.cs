using database.context.main;
namespace database.context.main.Repos
{
    public abstract class BaseRepos
    {
        protected readonly MainContext _db;

        public BaseRepos(MainContext db) => _db = db;
    }
}