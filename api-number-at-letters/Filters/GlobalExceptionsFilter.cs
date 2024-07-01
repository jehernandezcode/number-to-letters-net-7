using api_number_at_letters.Exceptions;
using api_number_at_letters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace api_number_at_letters.Filters
{
    public class GlobalExceptionsFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionsFilter> _logger;

        public GlobalExceptionsFilter(ILogger<GlobalExceptionsFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            _logger.LogError(exception, "Error Description");
            
            if (exception.GetType() == typeof(BadRequestException))
            {
                var validation = new
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Bad Request",
                    Detail = exception.Message
                };

                var json = new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = new[] { validation }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
            else if (exception.GetType() == typeof(UnAuthorizationException))
            {
                var validation = new
                {
                    Status = StatusCodes.Status403Forbidden,
                    Title = "Forbidden",
                    Detail = exception.Message
                };

                var json = new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.Forbidden,
                    Errors = new[] { validation }
                };

                context.Result = new ObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                context.ExceptionHandled = true;
            }
            else if (exception.GetType() == typeof(InternalServerException))
            {
                var validation = new
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Internal Error",
                    Detail = exception.Message
                };

                var json = new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Errors = new[] { validation }
                };

                context.Result = new ObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                context.ExceptionHandled = true;
            }
        }
    }
}
