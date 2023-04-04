using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace database.context.main.Models.Profile.LifePositions
{
    /// <summary>
    /// Информация, необходимая для обновления информации о жизненных позициях пользователя
    /// </summary>
    [Table("user_life_positions")]
    public sealed class ProfileLifePositionModel
    {
        /// <summary>
        /// Идентификатор связи между пользователем и выбранной жизненной позицией
        /// </summary>
        [Key]
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Required]
        [Column("user_id")]
        public int UserID { get; set; }

        /// <summary>
        /// Идентификатор жизненной позиции пользователя
        /// </summary>
        [Required]
        [Column("life_position_id")]
        public int PositionID { get; set; }

        public ProfileLifePositionModel(int userID, int positionID)
        {
            UserID = userID;
            PositionID = positionID;
        }

        public ProfileLifePositionModel() { }

    }
}