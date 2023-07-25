using db.v1.context.main.Contexts.Main.Interfaces;
using db.v1.context.main.Entities.Dictionary;

namespace db.v1.context.main.Repositories.Dictionary
{
    public sealed class DictionaryRepos : IDictionaryRepos
    {
        private readonly IDictionaryContext _db;

        public DictionaryRepos(IDictionaryContext dict) => _db = dict;

        public AppUserRoleEntity? GetAppUserRole(string tag) => _db.AppUserRoles
            .FirstOrDefault(x => x.Tag == tag);

        public List<AppUserRoleEntity> GetAppUserRoles() => _db.AppUserRoles
            .ToList();
    }
}