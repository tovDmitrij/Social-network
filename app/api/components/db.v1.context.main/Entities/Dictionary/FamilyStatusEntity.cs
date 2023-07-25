using System.ComponentModel.DataAnnotations.Schema;

namespace db.v1.context.main.Entities.Dictionary
{
    [Table("family_statuses")]
    public sealed class FamilyStatusEntity : BaseDictionaryEntity
    {
        public FamilyStatusEntity(Guid id, string name, string tag)
        {
            UUID = id;
            Name = name;
            Tag = tag;
        }

        public FamilyStatusEntity() { }
    }
}