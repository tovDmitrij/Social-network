using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace db.v1.context.main.Entities.Dictionary
{
    [Table("app_user_roles")]
    public sealed class AppUserRoleEntity
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("tag")]
        public string Tag { get; set; }

        public AppUserRoleEntity(int id, string name, string tag)
        {
            ID = id;
            Name = name;
            Tag = tag;
        }

        public AppUserRoleEntity() { }
    }
}