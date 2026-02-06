namespace Mash.Application.Commands;

public class MakeDirCommand(CommandContext ctx, ILogger logger) : ICommand
{
    public string Name => "mkdir";
    public int MinParameterCount => 1;
    
    public void Execute(string[] input)
    {
        if (input.Length > 2)
        {
            logger.PrintError("'mkdir' only has 1 argument");
            return;
        }
        
        string newDirectoryName = input[1];
        string fullNewDirectory = Path.Combine(ctx.WorkingDirectory, newDirectoryName);
        try
        {
            Directory.CreateDirectory(fullNewDirectory);
        }
        catch (Exception e)
        {
            logger.PrintError(e.Message);
        }
    }

    public void PrintHelp() => Console.WriteLine("mkdir <dir>: Creates a new directory with name 'dir' in the working directory");
}