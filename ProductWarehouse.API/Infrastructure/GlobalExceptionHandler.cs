using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;

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

		var problemDetails = exception switch
		{
			ValidatorException validationException => new ProblemDetails
			{
				Status = StatusCodes.Status400BadRequest,
				Title = "Validation Error",
				Detail = string.Join("; ", validationException.Errors.Select(error => $"{error.PropertyName}: {error.ErrorMessage}"))
			},
			InvalidOperationException or NotFoundException => new ProblemDetails
			{
				Status = StatusCodes.Status404NotFound,
				Title = exception.Message
			},
			BadHttpRequestException => new ProblemDetails
			{
				Status = StatusCodes.Status400BadRequest,
				Title = exception.Message
			},
			OperationCanceledException => new ProblemDetails
			{
				Status = StatusCodes.Status400BadRequest,
				Title = exception.Message
			},
			_ => new ProblemDetails
			{
				Status = StatusCodes.Status500InternalServerError,
				Title = "Internal Server Error"
			}
		};

		httpContext.Response.StatusCode = (int)problemDetails.Status;
		await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

		return true;
	}
}