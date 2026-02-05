namespace Mash.Application.Commands;

public class EchoCommand : Command
{
    public override int MinParameterCount => 1;
    public override string Name => "echo";
    
    public override void Execute(string[] input)
    {
        if (input.Length > 2)
        {
            Logger.PrintError("'echo' has 1 parameter.");
            return;
        }
        
        Console.WriteLine(input[1]);
    }

    public override void PrintHelp() => Console.WriteLine("echo <msg>: Prints the specified 'msg' to the console");
}