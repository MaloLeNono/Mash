using Mash.Application.Data;
using Mash.Application.Interface;

namespace Mash.Application.Commands;

public class ListCommand(CommandContext ctx, ILogger logger) : ICommand
{
    public string Name => "ls";
    public int MinParameterCount => 0;
    public int MaxParameterCount => 0;

    public void Execute(string[] input)
    {
        string[] files = Directory.GetFileSystemEntries(ctx.WorkingDirectory);
        foreach (string file in files)
        {
            if (File.Exists(file))
                Console.ForegroundColor = ConsoleColor.Blue;
            else if (Directory.Exists(file))
                Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.WriteLine(Path.GetFileName(file));
        }
        Console.ResetColor();
    }

    public void PrintHelp() => Console.WriteLine("ls: Lists all files in the working directory");
}