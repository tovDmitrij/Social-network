using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.main.Models.Data
{
    /// <summary>
    /// Полная информация о возможных семейных положениях пользователей в системе
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

        public FamilyStatusModel(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public FamilyStatusModel() { }
    }
}