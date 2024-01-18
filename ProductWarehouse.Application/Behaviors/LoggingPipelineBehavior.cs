using MediatR;
using Microsoft.Extensions.Logging;
using ProductWarehouse.Infrastructure.Logging;

namespace ProductWarehouse.Application.Behaviors;

public class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformationMessage(
            $"Starting request {typeof(TRequest).Name}");

        try
        {
            var response = await next();
            _logger.LogInformationMessage(
                $"Completed request {typeof(TRequest).Name}. Response: {typeof(TResponse).Name} ");

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                $"Exception thrown for request {typeof(TRequest).Name}");
            throw;
        }
    }
}
