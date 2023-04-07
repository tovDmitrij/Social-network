using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.main.Models.Profile.Careers
{
    /// <summary>
    /// Информация о карьере пользователя
    /// </summary>
    [Table("user_profile_carrer")]
    public sealed class ProfileCarrerModel
    {
        /// <summary>
        /// Идентификатор карьеры
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
        /// Идентификатор города
        /// </summary>
        [Required]
        [Column("city_id")]
        public int CityID { get; set; }

        /// <summary>
        /// Наименование компании
        /// </summary>
        [Required]
        [Column("company_name")]
        public string Company { get; set; }

        /// <summary>
        /// Наименование должности
        /// </summary>
        [Column("job")]
        public string? Job { get; set; }

        /// <summary>
        /// Дата начала карьеры
        /// </summary>
        [Column("date_from")]
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Дата окончания карьеры
        /// </summary>
        [Column("date_to")]
        public DateTime? DateTo { get; set; }

        public ProfileCarrerModel(int user_id, int city_id, string company, string? job, DateTime? date_from, DateTime? date_to)
        {
            UserID = user_id;
            CityID = city_id;
            Company = company;
            Job = job;
            DateFrom = date_from;
            DateTo = date_to;
        }

        public ProfileCarrerModel(int id, int user_id, int city_id, string company, string? job, DateTime? date_from, DateTime? date_to) : this(user_id, city_id, company, job, date_from, date_to) => ID = id;

        public ProfileCarrerModel() { }
    }
}