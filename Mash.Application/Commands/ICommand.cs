namespace Mash.Application.Commands;

public interface ICommand
{
    public string Name { get; }
    public int MinParameterCount { get; }
    public void Execute(string[] input);
    public void PrintHelp();
}