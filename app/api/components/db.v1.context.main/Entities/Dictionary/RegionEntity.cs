using System.ComponentModel.DataAnnotations.Schema;

namespace db.v1.context.main.Entities.Dictionary
{
    [Table("regions")]
    public sealed class RegionEntity : BaseDictionaryEntity
    {
        public int CountryID { get; set; }

        public RegionEntity(int id, int country_id, string name, string tag)
        {
            ID = id;
            CountryID = country_id;
            Name = name;
            Tag = tag;
        }

        public RegionEntity() { }
    }
}
