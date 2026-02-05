namespace Mash.Application.Commands;

public class HelpCommand(CommandContext ctx) : Command
{
    public override int MinParameterCount => 0;
    public override string Name => "help";

    public override void Execute(string[] input)
    {
        foreach (Command command in ctx.RegisteredCommands) 
            command.PrintHelp();
    }

    public override void PrintHelp() => Console.WriteLine("help: The help command. Duh");
}