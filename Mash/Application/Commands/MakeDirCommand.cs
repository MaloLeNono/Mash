namespace Mash.Application.Commands;

public class MakeDirCommand(CommandContext ctx) : Command
{
    public override int MinParameterCount => 1;
    public override string Name => "mkdir";
    
    public override void Execute(string[] input)
    {
        string newDirectoryName = input[1];
        string fullNewDirectory = Path.Combine(ctx.WorkingDirectory, newDirectoryName);
        try
        {
            Directory.CreateDirectory(fullNewDirectory);
        }
        catch (Exception e)
        {
            Logger.PrintError(e.Message);
        }
    }

    public override void PrintHelp() => Console.WriteLine("mkdir <dir>: Creates a new directory with name 'dir' in the working directory");
}