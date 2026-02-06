using Mash.Application.Data;
using Mash.Application.Interface;

namespace Mash.Application.Commands;

public class MakeFileCommand(CommandContext ctx, ILogger logger) : ICommand
{
    public string Name => "mkfile";
    public int MinParameterCount => 1;
    public int MaxParameterCount => 1;

    public void Execute(string[] input)
    {
        string fileName = input[1];
        string fullPath = Path.Combine(ctx.WorkingDirectory, fileName);
        using FileStream stream = File.Create(fullPath);
    }

    public void PrintHelp() => Console.WriteLine("mkfile <file>: Creates a file called 'file'");
}