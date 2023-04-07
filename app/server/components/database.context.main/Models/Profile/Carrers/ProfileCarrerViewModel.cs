using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace database.context.main.Models.Profile.Careers
{
    /// <summary>
    /// Подробная информация о карьере пользователя
    /// </summary>
    [Keyless]
    [Table("view_profile_carrer")]
    public sealed class ProfileCarrerViewModel
    {
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
        [Column("city_name")]
        public string City { get; set; }

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

        public ProfileCarrerViewModel(int user_id, string city_name, string company, string? job, DateTime? dateFrom, DateTime? dateTo)
        {
            UserID = user_id;
            City = city_name;
            Company = company;
            Job = job;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        public ProfileCarrerViewModel() { }
    }
}