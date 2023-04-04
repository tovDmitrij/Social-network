using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using database.context.Models.Data;
namespace api.Controllers
{
    /// <summary>
    /// Базовый контроллер API социальной сети
    /// </summary>
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Добавить лог в базу данных
        /// </summary>
        /// <param name="message">Сообщение об исключении</param>
        /// <param name="stackTrace">Строковое представление стека вызовов, которые привели к возникновению исключения</param>
        /// <param name="source">Наименование объекта, которое вызвало исключение</param>
        protected void Log(string message, string stackTrace, string source)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    const string exchangeName = "direct_logs";
                    channel.ExchangeDeclare(
                        exchange: exchangeName,
                        type: ExchangeType.Direct);

                    channel.BasicPublish(
                        exchange: exchangeName,
                        routingKey: "log",
                        mandatory: false,
                        basicProperties: null,
                        body: Encoding.UTF8.GetBytes(JsonSerializer.Serialize<LogModel>(new(message, source, stackTrace))));
                }
            }
        }
    }
}