using Mash.Application.Application.Commands;

namespace Mash.Application.Commands;

public class ExitCommand(CommandContext ctx, ILogger logger) : ICommand
{
    public string Name => "exit";
    public int MinParameterCount => 0;
    
    public void Execute(string[] input)
    {
        if (input.Length > 1)
        {
            logger.PrintError("'exit' has no parameters");
            return;
        }
        
        Environment.Exit(0);
    }

    public void PrintHelp() => Console.WriteLine("'exit': Exits the terminal");
}