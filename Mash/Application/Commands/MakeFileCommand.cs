namespace Mash.Application.Commands;

public class MakeFileCommand(CommandContext ctx) : ICommand
{
    public string Name => "mkfile";
    public int MinParameterCount => 1;
    
    public void Execute(string[] input)
    {
        if (input.Length > 2)
        {
            Logger.PrintError("'mkfile' only has 1 argument");
            return;
        }

        string fileName = input[1];
        using FileStream stream = File.Create(fileName);
    }

    public void PrintHelp() => 
}