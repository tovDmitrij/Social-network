namespace database.context.Repos
{
    public abstract class BaseRepos
    {
        protected readonly DataContext _db;

        public BaseRepos(DataContext db) => _db = db;
    }
}