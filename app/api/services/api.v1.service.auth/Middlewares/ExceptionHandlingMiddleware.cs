using MassTransit;
using db.v1.context.logs.Models;
namespace api.v1.service.auth.Middlewares
{
    /// <summary>
    /// МиддлВаря-обработчик ошибок
    /// </summary>
    public sealed class ExceptionHandlingMiddleware
    {
        /// <summary>
        /// Обрабатываемый запрос
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// Взаимодействие с другими сервисами
        /// </summary>
        private readonly IBus _bus;

        public ExceptionHandlingMiddleware(RequestDelegate next, IBus bus) 
        {
            _next = next;
            _bus = bus;
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

                ISendEndpoint endpoint = await _bus.GetSendEndpoint(new Uri("rabbitmq://localhost/logs_create"));
                await endpoint.Send(new LogModel(ex.Message, ex.Source ?? "-1", ex.StackTrace ?? "-1"));

                return;
            }
        }
    }
}