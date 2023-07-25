using System.ComponentModel.DataAnnotations.Schema;

namespace db.v1.context.main.Entities.Dictionary
{
    [Table("countries")]
    public sealed class CountryEntity : BaseDictionaryEntity
    {
        public CountryEntity(Guid id, string name, string tag)
        {
            UUID = id;
            Name = name;
            Tag = tag;
        }

        public CountryEntity() { }
    }
}
