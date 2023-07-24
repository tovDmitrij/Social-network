using db.v1.context.main.Contexts.Main.Interfaces;
using db.v1.context.main.Entities.Dictionary;

namespace db.v1.context.main.Repositories.Dictionary
{
    public sealed class DictionaryRepos : IDictionaryRepos
    {
        private readonly IDictionaryContext _dict;

        public DictionaryRepos(IDictionaryContext dict) => _dict = dict;

        public AppUserRoleEntity GetAppUserRole(string tag) => _dict.AppUserRoles
            .First(x => x.Tag == tag);

        public List<AppUserRoleEntity> GetAppUserRoles() => _dict.AppUserRoles
            .ToList();
    }
}