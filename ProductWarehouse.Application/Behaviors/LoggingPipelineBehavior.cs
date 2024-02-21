using MediatR;
using Serilog;

namespace ProductWarehouse.Application.Behaviors;

public class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
	private readonly ILogger _logger;

	public LoggingPipelineBehavior(ILogger logger)
	{
		_logger = logger;
	}

	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		_logger.Information(
			$"Starting request {typeof(TRequest).Name}");

		try
		{
			var response = await next();
			_logger.Information(
				$"Completed request {typeof(TRequest).Name}. Response: {typeof(TResponse).Name} ");

			return response;
		}
		catch (Exception ex)
		{
			_logger.Error(ex,
				$"Exception thrown for request {typeof(TRequest).Name}");
			throw;
		}
	}
}