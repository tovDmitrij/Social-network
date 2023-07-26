using System.ComponentModel.DataAnnotations.Schema;

namespace db.v1.context.main.Entities.Dictionary
{
    [Table("cities")]
    public sealed class CityEntity : BaseDictionaryEntity
    {
        public int RegionID { get; set; }

        public CityEntity(int id, int region_id, string name, string tag)
        {
            ID = id;
            RegionID = region_id;
            Name = name;
            Tag = tag;
        }

        public CityEntity() { }
    }
}