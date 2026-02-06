using Mash.Application.Data;
using Mash.Application.Interface;

namespace Mash.Application.Commands;

public class ExitCommand(CommandContext ctx, ILogger logger) : ICommand
{
    public string Name => "exit";
    public int MinParameterCount => 0;
    public int MaxParameterCount => 0;

    public void Execute(string[] input) => ctx.ShouldExit = true;

    public void PrintHelp() => Console.WriteLine("exit: Exits the terminal");
}