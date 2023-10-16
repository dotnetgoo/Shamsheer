using Shamsheer.Service.Exceptions;
using Shamsheer.Messenger.Api.Models;

namespace Shamsheer.Messenger.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ShamsheerException exception)
            {
                context.Response.StatusCode = exception.StatusCode;
                await context.Response.WriteAsJsonAsync(new Response
                {
                    Code = exception.StatusCode,
                    Message = exception.Message
                });
            }
            catch (Exception exception)
            {
                this.logger.LogError($"{exception}\n\n");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new Response
                {
                    Code = 500,
                    Message = exception.Message
                });
            }
        }
    }
}
