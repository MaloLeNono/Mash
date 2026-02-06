using System.Text;
using Mash.Application.Application.Commands;

namespace Mash.Application.Commands;

public class ListCommand(CommandContext ctx, ILogger logger) : ICommand
{
    public string Name => "ls";
    public int MinParameterCount => 0;
    
    public void Execute(string[] input)
    {
        string[] directories = Directory.GetDirectories(ctx.WorkingDirectory);
        StringBuilder responseBuilder = new();
        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (string directory in directories)
        {
            responseBuilder.Append(Path.GetFileName(directory));
            responseBuilder.Append('\n');
        }
        Console.WriteLine(responseBuilder.ToString());
        Console.ResetColor();
    }

    public void PrintHelp() => Console.WriteLine("ls: Lists all files in the working directory");
}