using System.ComponentModel.DataAnnotations.Schema;

namespace db.v1.context.main.Entities.Dictionary
{
    [Table("family_statuses")]
    public sealed class FamilyStatusEntity : BaseDictionaryEntity
    {
        public FamilyStatusEntity(int id, string name, string tag)
        {
            ID = id;
            Name = name;
            Tag = tag;
        }

        public FamilyStatusEntity() { }
    }
}