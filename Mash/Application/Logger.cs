namespace Mash.Application;

public static class Logger
{
    public static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[ERROR]\t{message}");
        Console.ResetColor();
    }
}