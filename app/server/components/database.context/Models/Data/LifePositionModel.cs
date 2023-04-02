using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Data
{
    /// <summary>
    /// Модель с информацией о жизненной позицией пользователя, определённой на платформе
    /// </summary>
    [Keyless]
    [Table("view_life_positions")]
    public sealed class LifePositionModel
    {
        /// <summary>
        /// Идентификатор жизненной позиции
        /// </summary>
        [Required]
        [Column("id")]
        public int PositionID { get; set; }

        /// <summary>
        /// Наименование жизненной позиции
        /// </summary>
        [Required]
        [Column("position_name")]
        public string PositionName { get; set; }

        /// <summary>
        /// Идентификатор типа жизненной позиции
        /// </summary>
        [Required]
        [Column("type_id")]
        public int TypeID { get; set; }

        /// <summary>
        /// Наименование типа жизненной позиции
        /// </summary>
        [Required]
        [Column("type_name")]
        public string TypeName { get; set; }

        public LifePositionModel(int id, string position_name, int type_id, string type_title)
        {
            PositionID = id;
            PositionName = position_name;
            TypeID = type_id;
            TypeName = type_title;
        }

        public LifePositionModel() { }
    }
}