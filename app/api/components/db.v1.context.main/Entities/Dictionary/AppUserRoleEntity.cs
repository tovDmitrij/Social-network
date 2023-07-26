using System.ComponentModel.DataAnnotations.Schema;

namespace db.v1.context.main.Entities.Dictionary
{
    [Table("app_user_roles")]
    public sealed class AppUserRoleEntity : BaseDictionaryEntity
    {
        public AppUserRoleEntity(int id, string name, string tag)
        {
            ID = id;
            Name = name;
            Tag = tag;
        }

        public AppUserRoleEntity() { }
    }
}