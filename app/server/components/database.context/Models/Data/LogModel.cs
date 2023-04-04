using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.context.Models.Data
{
    /// <summary>
    /// Информация о логе
    /// </summary>
    [Table("app_logs")]
    public sealed class LogModel
    {
        /// <summary>
        /// Идентификатор лога
        /// </summary>
        [Key]
        [Column("id")]
        public int ID { get; set; }

        /// <summary>
        /// Сообщение об исключении
        /// </summary>
        [Required]
        [Column("message")]
        public string Message { get; set; }

        /// <summary>
        /// Наименование объекта, которое вызвало исключение
        /// </summary>
        [Required]
        [Column("source")]
        public string Source { get; set; }

        /// <summary>
        /// Строковое представление стека вызовов, которые привели к возникновению исключения
        /// </summary>
        [Required]
        [Column("stack_trace")]
        public string StackTrace { get; set; }

        /// <summary>
        /// Дата возникновения ошибки
        /// </summary>
        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        public LogModel(string message, string source, string stack_trace)
        {
            Message = message;
            Source = source;
            StackTrace = stack_trace;
        }

        public LogModel(int id, string message, string source, string stack_trace, DateTime date)
        {
            ID = id;
            Message = message;
            Source = source;
            StackTrace = stack_trace;
            Date = date;
        }

        public LogModel() { }
    }
}
