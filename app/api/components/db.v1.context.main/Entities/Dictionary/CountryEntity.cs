using System.ComponentModel.DataAnnotations.Schema;

namespace db.v1.context.main.Entities.Dictionary
{
    [Table("countries")]
    public sealed class CountryEntity : BaseDictionaryEntity
    {
        public CountryEntity(int id, string name, string tag)
        {
            ID = id;
            Name = name;
            Tag = tag;
        }

        public CountryEntity() { }
    }
}
