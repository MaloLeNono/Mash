namespace Mash.Application.Interface;

public interface ICommand
{
    public string Name { get; }
    public int MinParameterCount { get; }
    public int MaxParameterCount { get; }
    public void Execute(string[] input);
    public void PrintHelp();
}