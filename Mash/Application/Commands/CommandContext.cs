namespace Mash.Application.Commands;

public class CommandContext(string workingDirectory, string userRootDirectory, List<Command> commands)
{
    public string WorkingDirectory { get; set; } = workingDirectory;
    public string UserRootDirectory { get; } = userRootDirectory;
    public List<Command> RegisteredCommands { get; } = commands;
}