using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace db.v1.context.logs.Models
{
    /// <summary>
    /// Информация о логе
    /// </summary>
    [Table("app_error_logs")]
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

        /// <summary>
        /// Информация о логе
        /// </summary>
        /// <param name="id">Идентификатор лога</param>
        /// <param name="message">Сообщение об исключении</param>
        /// <param name="source">Наименование объекта, которое вызвало исключение</param>
        /// <param name="stack_trace">Строковое представление стека вызовов, которые привели к возникновению исключения</param>
        /// <param name="date">Дата возникновения ошибки</param>
        public LogModel(int id, string message, string source, string stack_trace, DateTime date) : this(message, source, stack_trace)
        {
            ID = id;
            Date = date;
        }

        /// <summary>
        /// Информация о логе
        /// </summary>
        /// <param name="message">Сообщение об исключении</param>
        /// <param name="source">Наименование объекта, которое вызвало исключение</param>
        /// <param name="stack_trace">Строковое представление стека вызовов, которые привели к возникновению исключения</param>
        public LogModel(string message, string source, string stack_trace)
        {
            Message = message;
            Source = source;
            StackTrace = stack_trace;
        }

        /// <summary>
        /// Информация о логе
        /// </summary>
        public LogModel() { }
    }
}