using System.Runtime.CompilerServices;

namespace Logging.Analyzer.Test;

public static partial class LoggingExtensions
{
    private static Action<ILogger, Guid, Exception?> _logTestGuidCallback =
        LoggerMessage.Define<Guid>(
            LogLevel.Information,
            new EventId(1),
            "Test message: {Value}");

    public static void LogTestGuidWithoutGeneration(this ILogger logger, Guid value)
        => _logTestGuidCallback(logger, value, default);

    private static Action<ILogger, string, Exception?> _logTestStringCallback =
        LoggerMessage.Define<string>(
            LogLevel.Information,
            new EventId(1),
            "Test message: {Value}");

    public static void LogTestStringWithoutGeneration(this ILogger logger, string value)
        => _logTestStringCallback(logger, value, default);

    [LoggerMessage(
        Level = LogLevel.Information,
        EventId = 1,
        Message = "Test message: {Value}")]
    public static partial void LogTestGuid(this ILogger logger, Guid value);

    [LoggerMessage(
        Level = LogLevel.Information,
        EventId = 2,
        Message = "Test message: {Value}")]
    public static partial void LogTestString(this ILogger logger, string value);
}
