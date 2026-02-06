using Mash.Application;

namespace Mash.Infrastructure;

public class Logger : ILogger
{
    public void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[ERROR]\t{message}");
        Console.ResetColor();
    }
}