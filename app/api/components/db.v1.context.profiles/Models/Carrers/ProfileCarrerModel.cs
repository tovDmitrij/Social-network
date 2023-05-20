using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.profiles.Models.Careers
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

        /// <summary>
        /// Информация о карьере пользователя
        /// </summary>
        /// <param name="id">Идентификатор карьеры</param>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="city_id">Идентификатор города</param>
        /// <param name="company">Наименование компании</param>
        /// <param name="job">Наименование должности</param>
        /// <param name="date_from">Дата начала карьеры</param>
        /// <param name="date_to">Дата окончания карьеры</param>
        public ProfileCarrerModel(int id, int user_id, int city_id, string company, string? job, DateTime? date_from, DateTime? date_to) : this(user_id, city_id, company, job, date_from, date_to) => ID = id;

        /// <summary>
        /// Информация о карьере пользователя
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="city_id">Идентификатор города</param>
        /// <param name="company">Наименование компании</param>
        /// <param name="job">Наименование должности</param>
        /// <param name="date_from">Дата начала карьеры</param>
        /// <param name="date_to">Дата окончания карьеры</param>
        public ProfileCarrerModel(int user_id, int city_id, string company, string? job, DateTime? date_from, DateTime? date_to)
        {
            UserID = user_id;
            CityID = city_id;
            Company = company;
            Job = job;
            DateFrom = date_from;
            DateTo = date_to;
        }

        /// <summary>
        /// Информация о карьере пользователя
        /// </summary>
        public ProfileCarrerModel() { }
    }
}