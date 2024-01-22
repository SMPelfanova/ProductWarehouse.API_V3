using Microsoft.Extensions.Logging;

namespace ProductWarehouse.Application.Logging;

public static partial class LoggingMessageDefinitions
{
    [LoggerMessage(EventId = 10, Level = LogLevel.Information, Message = "")]
    public static partial void LogInformationMessage(this ILogger logger, string request);

}
