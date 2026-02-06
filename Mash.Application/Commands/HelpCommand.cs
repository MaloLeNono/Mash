namespace Mash.Application.Commands;

public class HelpCommand(CommandContext ctx, ILogger logger) : ICommand
{
    public string Name => "help";
    public int MinParameterCount => 0;
    
    public void Execute(string[] input)
    {
        if (input.Length > 1)
        {
            logger.PrintError("'help' has no parameters");
            return;
        }
        
        foreach (ICommand command in ctx.RegisteredCommands) 
            command.PrintHelp();
    }

    public void PrintHelp() => Console.WriteLine("help: The help command. Duh");
}