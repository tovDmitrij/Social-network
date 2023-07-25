using System.ComponentModel.DataAnnotations.Schema;

namespace db.v1.context.main.Entities.Dictionary
{
    [Table("regions")]
    public sealed class CityEntity : BaseDictionaryEntity
    {
        public Guid RegionID { get; set; }

        public CityEntity(Guid id, Guid region_id, string name, string tag)
        {
            UUID = id;
            RegionID = region_id;
            Name = name;
            Tag = tag;
        }

        public CityEntity() { }
    }
}