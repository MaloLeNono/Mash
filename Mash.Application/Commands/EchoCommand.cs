namespace Mash.Application.Commands;

public class EchoCommand(CommandContext ctx, ILogger logger) : ICommand
{
    public string Name => "echo";
    public int MinParameterCount => 1;
    
    public void Execute(string[] input)
    {
        if (input.Length > 2)
        {
            logger.PrintError("'echo' has 1 parameter.");
            return;
        }
        
        Console.WriteLine(input[1]);
    }

    public void PrintHelp() => Console.WriteLine("echo <msg>: Prints the specified 'msg' to the console");
}