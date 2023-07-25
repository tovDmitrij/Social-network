using System.ComponentModel.DataAnnotations.Schema;

namespace db.v1.context.main.Entities.Dictionary
{
    [Table("regions")]
    public sealed class RegionEntity : BaseDictionaryEntity
    {
        public Guid CountryID { get; set; }

        public RegionEntity(Guid id, Guid country_id, string name, string tag)
        {
            UUID = id;
            CountryID = country_id;
            Name = name;
            Tag = tag;
        }

        public RegionEntity() { }
    }
}
