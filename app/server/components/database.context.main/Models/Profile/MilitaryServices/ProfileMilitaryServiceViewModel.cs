using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.main.Models.Profile.MilitaryServices
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

        public ProfileMilitaryServiceViewModel() { }
    }
}