using Mash.Application.Data;
using Mash.Application.Interface;

namespace Mash.Application.Commands;

public class EchoCommand(CommandContext ctx, ILogger logger) : ICommand
{
    public string Name => "echo";
    public int MinParameterCount => 1;
    public int MaxParameterCount => 1;

    public void Execute(string[] input) => Console.WriteLine(input[1]);
    public void PrintHelp() => Console.WriteLine("echo <msg>: Prints the specified 'msg' to the console");
}