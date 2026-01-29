using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Notices.Infrastructure.Middleware;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Wystąpił błąd: {Message}", exception.Message);
        var (statusCode, title) = exception switch
        {
            UnauthorizedAccessException => (StatusCodes.Status403Forbidden, "Brak dostepu"),
            KeyNotFoundException => (StatusCodes.Status404NotFound, "Nie znaleziono zasobu"),
            _ => (StatusCodes.Status500InternalServerError, "Blad serwera")

        };
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = exception.Message,
            Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
        }, cancellationToken);
        
        return true;
    }
}