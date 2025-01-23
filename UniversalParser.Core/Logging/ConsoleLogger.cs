using UniversalParser.SharedKernel.Interfaces;

namespace UniversalParser.Core.Logging;

public class ConsoleLogger : ILogger
{
    public void LogInfo(string message)
    {
        Console.WriteLine($"{message}");
    }

    public void LogWarning(string message)
    {
        Console.WriteLine($"WARNING: {message}");
    }

    public void LogError(string message)
    {
        Console.WriteLine($"ERROR: {message}");
    }

    public void LogError(string methodName, Exception exception)
    {
        Console.WriteLine($"{DateTime.Now}: ERROR in {methodName}");
        Console.WriteLine($" - Exception Message: {exception.Message}");
        if (exception.StackTrace != null)
        {
            Console.WriteLine($" - StackTrace: {exception.StackTrace}");
        }
    }
}