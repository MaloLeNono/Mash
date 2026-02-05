namespace Mash.Application.Commands;

public abstract class Command
{
    public abstract int MinParameterCount { get; }
    public abstract string Name { get; }
    public abstract void Execute(string[] input);
    public abstract void PrintHelp();
}