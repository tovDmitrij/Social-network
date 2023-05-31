using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.profiles.Models.Profiles.MilitaryServices
{
    /// <summary>
    /// Информация о военной службе пользователя
    /// </summary>
    [Table("user_profile_military_services")]
    public sealed class ProfileMilitaryServiceModel
    {
        /// <summary>
        /// Идентификатор военной службы
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
        /// Идентификатор страны проведения военной службы
        /// </summary>
        [Required]
        [Column("country_id")]
        public int CountryID { get; set; }

        /// <summary>
        /// Военная часть
        /// </summary>
        [Required]
        [Column("military_unit")]
        public string MilitaryUnit { get; set; }

        /// <summary>
        /// Дата начала военной службы
        /// </summary>
        [Column("date_from")]
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Дата окончания военной службы
        /// </summary>
        [Column("date_to")]
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// Информация о военной службе пользователя
        /// </summary>
        /// <param name="id">Идентификатор военной службы</param>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="country_id">Идентификатор страны проведения военной службы</param>
        /// <param name="military_unit">Военная часть</param>
        /// <param name="date_from">Дата начала военной службы</param>
        /// <param name="date_to">Дата окончания военной службы</param>
        public ProfileMilitaryServiceModel(int id, int user_id, int country_id, string military_unit, 
                                           DateTime? date_from, DateTime? date_to) : 
                                           this(user_id, country_id, military_unit, date_from, date_to) => ID = id;

        /// <summary>
        /// Информация о военной службе пользователя
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="country_id">Идентификатор страны проведения военной службы</param>
        /// <param name="military_unit">Военная часть</param>
        /// <param name="date_from">Дата начала военной службы</param>
        /// <param name="date_to">Дата окончания военной службы</param>
        public ProfileMilitaryServiceModel(int user_id, int country_id, string military_unit, 
                                           DateTime? date_from, DateTime? date_to)
        {
            UserID = user_id;
            CountryID = country_id;
            MilitaryUnit = military_unit;
            DateFrom = date_from;
            DateTo = date_to;
        }

        /// <summary>
        /// Информация о военной службе пользователя
        /// </summary>
        public ProfileMilitaryServiceModel() { }
    }
}