using OnionArchitecture.Services.Interfaces.Exceptions;
using System.Net;
using System.Text.Json;

namespace OnionArchitecture.Presentation.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(RequestDelegate next) =>
            this.next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode code;
            var message = exception.Message;
            ErrorMessage error = new();

            switch (exception)
            {
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case Services.Interfaces.Exceptions.ArgumentException:
                    code = HttpStatusCode.BadRequest;
                    break;
                case AlreadyExistsException:
                    code = HttpStatusCode.Conflict;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    message = "Internal server error";
                    break;
            }

            error.Message = message;
            error.StatusCode = (int)code;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }
    }
}
