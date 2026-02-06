using Mash.Application.Application.Commands;

namespace Mash.Application.Commands;

public class CommandContext(string workingDirectory, string userRootDirectory, List<ICommand> commands)
{
    public string WorkingDirectory { get; set; } = workingDirectory;
    public string UserRootDirectory { get; } = userRootDirectory;
    public List<ICommand> RegisteredCommands { get; } = commands;
}