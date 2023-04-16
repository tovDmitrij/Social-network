using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
namespace api.service.profile.Middlewares
{
    /// <summary>
    /// МиддлВаря-обработчик ошибок
    /// </summary>
    public sealed class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsJsonAsync(new { statusCode = 500, status = "Произошла непредвиденная ошибка. Повторите позже" });

                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.ExchangeDeclare(
                            exchange: "direct_logs",
                            type: ExchangeType.Direct);

                        channel.BasicPublish(
                            exchange: "direct_logs",
                            routingKey: "error",
                            mandatory: false,
                            basicProperties: null,
                            body: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(
                                new { ex.Message, ex.Source, ex.StackTrace},
                                new JsonSerializerOptions() { WriteIndented=true})));
                    }
                }
            }
        }
    }
}