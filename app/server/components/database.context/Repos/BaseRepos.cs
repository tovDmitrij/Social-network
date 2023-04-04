using database.context.Contexts;
namespace database.context.Repos
{
    public abstract class BaseRepos
    {
        protected readonly MainContext _db;

        public BaseRepos(MainContext db) => _db = db;
    }
}