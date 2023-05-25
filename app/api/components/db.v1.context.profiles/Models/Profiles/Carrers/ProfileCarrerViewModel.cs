using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace db.v1.context.profiles.Models.Profiles.Carrers
{
    /// <summary>
    /// Подробная информация о карьере пользователя
    /// </summary>
    [Table("view_profile_carrers")]
    public sealed class ProfileCarrerViewModel
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
        /// Наименование города
        /// </summary>
        [Required]
        [Column("city_name")]
        public string CityName { get; set; }

        /// <summary>
        /// Наименование компании
        /// </summary>
        [Required]
        [Column("company")]
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
        /// Подробная информация о карьере пользователя
        /// </summary>
        /// <param name="id">Идентификатор карьеры</param>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="city_id">Идентификатор города</param>
        /// <param name="city_name">Наименование города</param>
        /// <param name="company">Наименование компании</param>
        /// <param name="job">Наименование должности</param>
        /// <param name="dateFrom">Дата начала карьеры</param>
        /// <param name="dateTo">Дата окончания карьеры</param>
        public ProfileCarrerViewModel(int id, int user_id, int city_id, string city_name, string company, string? job, DateTime? dateFrom, DateTime? dateTo)
        {
            ID = id;
            UserID = user_id;
            CityID = city_id;
            CityName = city_name;
            Company = company;
            Job = job;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        /// <summary>
        /// Подробная информация о карьере пользователя
        /// </summary>
        public ProfileCarrerViewModel() { }
    }
}