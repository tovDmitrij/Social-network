using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace db.v1.context.profiles.Models.LifePositions
{
    /// <summary>
    /// Информация о жизненной позиции пользователя
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
        /// Идентификатор жизненной позиции
        /// </summary>
        [Required]
        [Column("life_position_id")]
        public int PositionID { get; set; }

        /// <summary>
        /// Информация о жизненной позиции пользователя
        /// </summary>
        /// <param name="id">Идентификатор связи между пользователем и выбранной жизненной позицией</param>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="life_position_id">Идентификатор жизненной позиции</param>
        public ProfileLifePositionModel(int id, int user_id, int life_position_id) : this(user_id, life_position_id) => ID = id;

        /// <summary>
        /// Информация о жизненной позиции пользователя
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="life_position_id">Идентификатор жизненной позиции</param>
        public ProfileLifePositionModel(int user_id, int life_position_id)
        {
            UserID = user_id;
            PositionID = life_position_id;
        }

        /// <summary>
        /// Информация о жизненной позиции пользователя
        /// </summary>
        public ProfileLifePositionModel() { }

    }
}