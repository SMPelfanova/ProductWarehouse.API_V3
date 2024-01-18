using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Exceptions;

namespace ProductWarehouse.API.Infrastructure;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Exception occured {Message}.", exception.Message);

        if (exception is ValidatorException validationException)
        {
            var validationErrors = validationException.Errors.Select(error => new
            {
                Property = error.PropertyName,
                Message = error.ErrorMessage
            });

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsJsonAsync(validationErrors, cancellationToken);

            return true;
        }

        var problemDetails = new ProblemDetails();

        switch (exception)
        {
            case BadHttpRequestException:
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Title = exception.GetType().Name;
                break;
            default:
                problemDetails.Status = StatusCodes.Status500InternalServerError;
                problemDetails.Title = "Internal Server Error";
                break;
        }

        httpContext.Response.StatusCode = (int)problemDetails.Status;
        await httpContext
            .Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
