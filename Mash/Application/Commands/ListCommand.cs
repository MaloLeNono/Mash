using System.Text;

namespace Mash.Application.Commands;

public class ListCommand(CommandContext ctx) : Command
{
    public override int MinParameterCount => 0;
    public override string Name => "ls";

    public override void Execute(string[] input)
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

    public override void PrintHelp() => Console.WriteLine("ls: Lists all files in the working directory");
}