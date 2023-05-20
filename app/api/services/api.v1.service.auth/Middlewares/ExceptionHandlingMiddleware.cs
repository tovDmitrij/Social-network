using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
namespace api.v1.service.auth.Middlewares
{
    /// <summary>
    /// МиддлВаря-обработчик ошибок
    /// </summary>
    public sealed class ExceptionHandlingMiddleware : IDisposable
    {
        private readonly RequestDelegate _next;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public ExceptionHandlingMiddleware(RequestDelegate next) 
        {
            _next = next;

            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsJsonAsync(new { statusCode = 500, status = "Произошла непредвиденная ошибка. Повторите позже" });

                _channel.ExchangeDeclare(
                    exchange: "direct_logs",
                    type: ExchangeType.Direct);

                _channel.BasicPublish(
                    exchange: "direct_logs",
                    routingKey: "error",
                    mandatory: false,
                    basicProperties: null,
                    body: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(
                        new { ex.Message, ex.Source, ex.StackTrace},
                        new JsonSerializerOptions() { WriteIndented=true})));
            }
        }

        public void Dispose()
        {
            _channel.Dispose();
            _connection.Dispose();
        }
    }
}