using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.profiles.Models.MilitaryServices
{
    /// <summary>
    /// Подробная информация о военной службе пользователя
    /// </summary>
    [Table("view_profile_military_services")]
    public sealed class ProfileMilitaryServiceViewModel
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
        /// Наименование страны проведения ВС
        /// </summary>
        [Required]
        [Column("country_name")]
        public string CountryName { get; set; }

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
        /// Подробная информация о военной службе пользователя
        /// </summary>
        /// <param name="id">Идентификатор военной службы</param>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="country_id">Идентификатор страны проведения военной службы</param>
        /// <param name="country_name">Наименование страны проведения ВС</param>
        /// <param name="military_unit">Военная часть</param>
        /// <param name="date_from">Дата начала военной службы</param>
        /// <param name="date_to">Дата окончания военной службы</param>
        public ProfileMilitaryServiceViewModel(int id, int user_id, int country_id, string country_name, string military_unit, DateTime? date_from, DateTime? date_to)
        {
            ID = id;
            UserID = user_id;
            CountryID = country_id;
            CountryName = country_name;
            MilitaryUnit = military_unit;
            DateFrom = date_from;
            DateTo = date_to;
        }

        /// <summary>
        /// Подробная информация о военной службе пользователя
        /// </summary>
        public ProfileMilitaryServiceViewModel() { }
    }
}