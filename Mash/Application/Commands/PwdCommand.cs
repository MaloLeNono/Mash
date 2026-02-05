namespace Mash.Application.Commands;

public class PwdCommand(CommandContext ctx) : Command
{
    public override int MinParameterCount => 0;
    public override string Name => "pwd";

    public override void Execute(string[] input)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(ctx.WorkingDirectory);
        Console.ResetColor();
    }

    public override void PrintHelp() => Console.WriteLine("pwd: Prints the working directory");
}