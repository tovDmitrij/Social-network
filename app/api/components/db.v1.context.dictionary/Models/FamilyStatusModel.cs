using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.dictionary.Models
{
    /// <summary>
    /// Информация о семейном положении пользователя
    /// </summary>
    [Table("family_statuses")]
    public sealed class FamilyStatusModel
    {
        /// <summary>
        /// Идентификатор семейного положения
        /// </summary>
        [Key]
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// Наименование семейного положения
        /// </summary>
        [Required]
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Информация о семейном положении пользователя
        /// </summary>
        /// <param name="id">Идентификатор семейного положения</param>
        /// <param name="name">Наименование семейного положения</param>
        public FamilyStatusModel(int id, string name)
        {
            ID = id;
            Name = name;
        }

        /// <summary>
        /// Информация о семейном положении пользователя
        /// </summary>
        public FamilyStatusModel() { }
    }
}