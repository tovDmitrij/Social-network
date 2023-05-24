using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.profiles.Models.Profiles.LifePositions
{
    /// <summary>
    /// Подробная информация о жизненной позиции пользователя
    /// </summary>
    [Keyless]
    [Table("view_profile_life_positions")]
    public sealed class ProfileLifePositionViewModel
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

        /// <summary>
        /// Подробная информация о жизненной позиции пользователя
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="type_id">Идентификатор типа жизненной позиции</param>
        /// <param name="type_name">Наименование типа жизненной позиции</param>
        /// <param name="position_id">Идентификатор жизненной позиции</param>
        /// <param name="position_name">Наименование жизненной позиции</param>
        /// <param name="date">Дата добавления жизненной позиции пользователем</param>
        public ProfileLifePositionViewModel(int user_id, int type_id, string type_name, int position_id, string position_name, DateTime date)
        {
            UserID = user_id;
            TypeID = type_id;
            TypeName = type_name;
            PositionID = position_id;
            PositionName = position_name;
            Date = date;
        }

        /// <summary>
        /// Подробная информация о жизненной позиции пользователя
        /// </summary>
        public ProfileLifePositionViewModel() { }
    }
}