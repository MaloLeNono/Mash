namespace Mash.Application.Commands;

public class ClearCommand : Command
{
    public override int MinParameterCount => 0;
    public override string Name => "clear"; 
        
    public override void Execute(string[] input) => Console.Clear();
    public override void PrintHelp() => Console.WriteLine("clear: Clears the console screen");
}