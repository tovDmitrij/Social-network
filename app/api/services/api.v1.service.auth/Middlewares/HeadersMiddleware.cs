namespace api.v1.service.auth.Middlewares
{
    /// <summary>
    /// МиддлВаря-обработчик заголовка запроса
    /// </summary>
    public sealed class HeadersMiddleware
    {
        /// <summary>
        /// Обрабатываемый запрос
        /// </summary>
        private readonly RequestDelegate _next;

        public HeadersMiddleware(RequestDelegate next) => _next = next;

        /// <summary>
        /// Вызов запрашиваемого эндпоинта и его обработка
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            IHeaderDictionary headers = context.Response.Headers;
            headers["Content-type"] = "application/json";
            headers["Content-security-policy"] = "script-src 'self'";
            headers["X-Content-Type-Options"] = "nosniff";
            headers["X-Frame-Options"] = "DENY";
            headers["X-xss-protection"] = "1; mode=block";
            headers["Referrer-Policy"] = "no-referrer";

            await _next(context);
        }
    }
}