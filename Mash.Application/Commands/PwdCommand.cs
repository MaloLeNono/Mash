namespace Mash.Application.Commands;

public class PwdCommand(CommandContext ctx, ILogger logger) : ICommand
{
    public string Name => "pwd";
    public int MinParameterCount => 0;
    
    public void Execute(string[] input)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(ctx.WorkingDirectory);
        Console.ResetColor();
    }

    public void PrintHelp() => Console.WriteLine("pwd: Prints the working directory");
}