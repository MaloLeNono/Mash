using Mash.Application.Data;
using Mash.Application.Interface;

namespace Mash.Application.Commands;

public class ClearCommand(CommandContext ctx, ILogger logger) : ICommand
{
    public string Name => "clear";
    public int MinParameterCount => 0;
    public int MaxParameterCount => 0;

    public void Execute(string[] input) => Console.Clear();
    public void PrintHelp() => Console.WriteLine("clear: Clears the console screen");
}