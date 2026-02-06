using Mash.Application.Application.Commands;

namespace Mash.Application.Commands;

public class MakeFileCommand(CommandContext ctx, ILogger logger) : ICommand
{
    public string Name => "mkfile";
    public int MinParameterCount => 1;
    
    public void Execute(string[] input)
    {
        if (input.Length > 2)
        {
            logger.PrintError("'mkfile' only has 1 argument");
            return;
        }

        string fileName = input[1];
        using FileStream stream = File.Create(fileName);
    }

    public void PrintHelp() => Console.WriteLine("mkfile <file>: Creates a file called 'file'");
}