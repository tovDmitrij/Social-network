using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace db.v1.context.profiles.Models.Profiles.LifePositions
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
        /// Дата добавления жизненной позиции пользователем
        /// </summary>
        [Required]
        [Column("date")]
        public DateTime Date { get;set; }

        /// <summary>
        /// Информация о жизненной позиции пользователя
        /// </summary>
        /// <param name="id">Идентификатор связи между пользователем и выбранной жизненной позицией</param>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="life_position_id">Идентификатор жизненной позиции</param>
        /// <param name="date">Дата добавления жизненной позиции пользователем</param>
        public ProfileLifePositionModel(int id, int user_id, int life_position_id, DateTime date) : 
                                        this(user_id, life_position_id, date) => ID = id;

        /// <summary>
        /// Информация о жизненной позиции пользователя
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="life_position_id">Идентификатор жизненной позиции</param>
        /// <param name="date">Дата добавления жизненной позиции пользователем</param>
        public ProfileLifePositionModel(int user_id, int life_position_id, DateTime date)
        {
            UserID = user_id;
            PositionID = life_position_id;
            Date = date;
        }

        /// <summary>
        /// Информация о жизненной позиции пользователя
        /// </summary>
        public ProfileLifePositionModel() { }

    }
}