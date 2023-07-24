using api.v1.service.main.Exceptions;

namespace api.v1.service.main.Middlewares
{
    public sealed class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _request;

        public CustomExceptionHandlerMiddleware(RequestDelegate request) => _request = request;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (APIException e)
            {
                context.Response.StatusCode = e.StatusCode;
                await context.Response.WriteAsJsonAsync(e.Message);
            }
            catch
            { 
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync("Произошла непредвиденная ошибка. Повторите позже");
            }
        }
    }
}