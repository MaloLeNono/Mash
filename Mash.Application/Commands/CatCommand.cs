using Mash.Application.Data;
using Mash.Application.Interface;

namespace Mash.Application.Commands;

public class CatCommand(CommandContext ctx, ILogger logger) : ICommand
{
    public string Name => "cat";
    public int MinParameterCount => 1;
    public int MaxParameterCount => 1;

    public void Execute(string[] input)
    {
        string fileName = input[1];
        string fullPath = Path.Combine(ctx.WorkingDirectory, fileName);
        if (!File.Exists(fullPath))
        {
            logger.PrintError($"File at \"{fullPath}\" does not exist");
            return;
        }

        string fileContent = File.ReadAllText(fullPath);
        Console.WriteLine(fileContent);
    }

    public void PrintHelp() => Console.WriteLine("cat <filepath>: Read and print file contents at 'filepath' to the terminal screen");
}