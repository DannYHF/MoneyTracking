using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MoneyTracking.API.Helpers.ApiExceptions;

namespace MoneyTracking.API.Helpers
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.BadRequest; // 500 if unexpected

            if      (exception is NotFoundException)       code = HttpStatusCode.NotFound;
            else if (exception is InvalidRequestException) code = HttpStatusCode.BadRequest;
            else if (exception is AlreadyExistsException)  code = HttpStatusCode.Conflict;

            var result = JsonSerializer.Serialize(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}