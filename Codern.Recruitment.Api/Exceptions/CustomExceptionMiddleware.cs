using System.Net;

namespace Codern.Recruitment.Api.Exceptions;
public class CustomExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public CustomExceptionMiddleware(RequestDelegate next, ILogger logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message, exception);
            await HandleExceptionAsync(httpContext);
        }
    }

    private Task HandleExceptionAsync(HttpContext httpContext)
    {
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        httpContext.Response.ContentType = "application/json";

        return httpContext.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = httpContext.Response.StatusCode,
            Message = "Server Error."
        }.ToString());
    }
}
