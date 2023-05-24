using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
namespace api.service.profile.Middlewares
{
    /// <summary>
    /// МиддлВаря-обработчик ошибок
    /// </summary>
    public sealed class ExceptionHandlingMiddleware : IDisposable
    {
        /// <summary>
        /// Обрабатываемый запрос
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// Подключение к брокеру сообщений
        /// </summary>
        private readonly IConnection _connection;

        /// <summary>
        /// Канал связи с сервисом логирования ошибок
        /// </summary>
        private readonly IModel _channel;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;

            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(
                 exchange: "direct_logs",
                 type: ExchangeType.Direct);
        }

        /// <summary>
        /// Вызов запрашиваемого эндпоинта и его обработка
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsJsonAsync(new 
                { 
                    statusCode = 500, 
                    status = "Произошла непредвиденная ошибка. Повторите позже" 
                });

                _channel.BasicPublish(
                    exchange: "direct_logs",
                    routingKey: "error",
                    body: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(
                        new { ex.Message, ex.Source, ex.StackTrace },
                        new JsonSerializerOptions() { WriteIndented = true })));
                return;
            }
        }

        public void Dispose()
        {
            if (_connection.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }
    }
}