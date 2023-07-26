using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace db.v1.context.main.Entities.Dictionary
{
    public abstract class BaseDictionaryEntity
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
    }
}