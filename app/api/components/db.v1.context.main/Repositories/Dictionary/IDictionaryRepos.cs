using db.v1.context.main.Entities.Dictionary;

namespace db.v1.context.main.Repositories.Dictionary
{
    public interface IDictionaryRepos
    {
        public AppUserRoleEntity GetAppUserRole(string tag);
        public List<AppUserRoleEntity> GetAppUserRoles();
    }
}