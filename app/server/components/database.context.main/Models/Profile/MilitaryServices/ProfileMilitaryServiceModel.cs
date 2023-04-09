using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.main.Models.Profile.MilitaryServices
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

        public ProfileMilitaryServiceModel(int user_id, int country_id, string military_unit, DateTime? date_from, DateTime? date_to)
        {
            UserID = user_id;
            CountryID = country_id;
            MilitaryUnit = military_unit;
            DateFrom = date_from;
            DateTo = date_to;
        }

        public ProfileMilitaryServiceModel(int id, int user_id, int country_id, string military_unit, DateTime? date_from, DateTime? date_to)
        {
            ID = id;
            UserID = user_id;
            CountryID = country_id;
            MilitaryUnit = military_unit;
            DateFrom = date_from;
            DateTo = date_to;
        }

        public ProfileMilitaryServiceModel() { }
    }
}