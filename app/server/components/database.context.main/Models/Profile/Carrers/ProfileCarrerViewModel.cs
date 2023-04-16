using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace database.context.main.Models.Profile.Careers
{
    /// <summary>
    /// Подробная информация о карьере пользователя
    /// </summary>
    [Table("view_profile_carrer")]
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

        public ProfileCarrerViewModel() { }
    }
}