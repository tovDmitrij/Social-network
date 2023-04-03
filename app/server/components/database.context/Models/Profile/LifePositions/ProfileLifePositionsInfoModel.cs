using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Profile.LifePositions
{
    /// <summary>
    /// Полная информация о выбранных жизненных позициях пользователей
    /// </summary>
    [Keyless]
    [Table("view_profile_life_positions")]
    public sealed class ProfileLifePositionsInfoModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Required]
        [Column("user_id")]
        public int UserID { get; set; }

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
        /// Идентификатор жизненной позиции
        /// </summary>
        [Required]
        [Column("position_id")]
        public int PositionID { get; set; }

        /// <summary>
        /// Наименование жизненной позиции
        /// </summary>
        [Required]
        [Column("position_name")]
        public string PositionName { get; set; }

        /// <summary>
        /// Дата добавления жизненной позиции пользователем
        /// </summary>
        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        public ProfileLifePositionsInfoModel(int userID, int typeID, string typeName, int positionID, string positionName, DateTime date)
        {
            UserID = userID;
            TypeID = typeID;
            TypeName = typeName;
            PositionID = positionID;
            PositionName = positionName;
            Date = date;
        }

        public ProfileLifePositionsInfoModel() { }
    }
}