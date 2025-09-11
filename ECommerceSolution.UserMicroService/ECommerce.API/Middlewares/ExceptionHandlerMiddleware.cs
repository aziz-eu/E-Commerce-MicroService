using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ECommerce.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
               await _next(httpContext);
            }
            catch (Exception ex) {

                _logger.LogError($"LogError : {ex.GetType().ToString()}, ErrorMessage: {ex.Message}");


                if(ex.InnerException is not null)
                {
                    _logger.LogError($"LogError : {ex.InnerException.GetType().ToString()}, ErrorMessage: {ex.InnerException.Message}");
                }

                await httpContext.Response.WriteAsJsonAsync(new { ErrorMessage = ex.Message, Type = ex.GetType().ToString() });
            }

            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
