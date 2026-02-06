using Mash.Application.Data;
using Mash.Application.Interface;

namespace Mash.Application.Commands;

public class MaloCommand(CommandContext ctx, ILogger logger) : ICommand
{
    public string Name => "malo";
    public int MinParameterCount => 0;
    public int MaxParameterCount => 0;

    public void Execute(string[] input) => Console.WriteLine("hi thats me");

    public void PrintHelp() => Console.WriteLine("malo: The malo command");
}