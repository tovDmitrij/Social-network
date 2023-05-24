using misc.jwt;
namespace api.v1.service.profiles.Middlewares
{
    /// <summary>
    /// МиддлВаря-обработчик JWT-токена
    /// </summary>
    public sealed class TokenMiddleware
    {
        /// <summary>
        /// Обрабатываемый запрос
        /// </summary>
        private readonly RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next) => _next = next;

        /// <summary>
        /// Вызов запрашиваемого эндпоинта и его обработка
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            if (AuthToken.GetUserID(context.Request.Headers) == -1)
            {
                await context.Response.WriteAsJsonAsync(new
                {
                    statusCode = 401,
                    status = "Токен пользователя повреждён или не соответствует действительности"
                }, CancellationToken.None);
                return;
            }

            await _next(context);
        }
    }
}