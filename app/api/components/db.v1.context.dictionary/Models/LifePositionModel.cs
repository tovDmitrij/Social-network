using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.dictionary.Models
{
    /// <summary>
    /// Информация о жизненной позиции пользователя
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

        /// <summary>
        /// Информация о жизненной позиции пользователя
        /// </summary>
        /// <param name="id">Идентификатор жизненной позиции</param>
        /// <param name="position_name">Наименование жизненной позиции</param>
        /// <param name="type_id">Идентификатор типа жизненной позиции</param>
        /// <param name="type_title">Наименование типа жизненной позиции</param>
        public LifePositionModel(int id, string position_name, int type_id, string type_title)
        {
            PositionID = id;
            PositionName = position_name;
            TypeID = type_id;
            TypeName = type_title;
        }

        /// <summary>
        /// Информация о жизненной позиции пользователя
        /// </summary>
        public LifePositionModel() { }
    }
}