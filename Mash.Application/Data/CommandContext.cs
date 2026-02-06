using Mash.Application.Interface;

namespace Mash.Application.Data;

public class CommandContext(string workingDirectory, string userRootDirectory, Dictionary<string, ICommand> commands)
{
    public string WorkingDirectory { get; set; } = workingDirectory;
    public string UserRootDirectory { get; } = userRootDirectory;
    public Dictionary<string, ICommand> RegisteredCommands { get; } = commands;
    public bool ShouldExit { get; set; }
}