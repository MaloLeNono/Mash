using Mash.Application.Data;
using Mash.Application.Interface;

namespace Mash.Application.Commands;

public class HelpCommand(CommandContext ctx, ILogger logger) : ICommand
{
    public string Name => "help";
    public int MinParameterCount => 0;
    public int MaxParameterCount => 0;

    public void Execute(string[] input)
    {
        foreach (ICommand command in ctx.RegisteredCommands.Values) 
            command.PrintHelp();
    }

    public void PrintHelp() => Console.WriteLine("help: The help command. Duh");
}