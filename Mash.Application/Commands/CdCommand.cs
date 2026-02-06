namespace Mash.Application.Commands;

public class CdCommand(CommandContext ctx, ILogger logger) : ICommand
{
    public string Name => "cd";
    public int MinParameterCount => 0;

    public void Execute(string[] input)
    {
        if (input.Length > 2)
        {
            logger.PrintError("'cd' command only takes 1 argument");
            return;
        }

        if (input.Length == 1)
        {
            ctx.WorkingDirectory = ctx.UserRootDirectory;
            return;
        }

        string directoryToMoveTo = input[1];

        if (directoryToMoveTo == "..")
        {
            DirectoryInfo? parentDirectory = Directory.GetParent(ctx.WorkingDirectory);

            if (parentDirectory is null)
            {
                logger.PrintError("There is no higher directory");
                return;
            }

            ctx.WorkingDirectory = parentDirectory.FullName;

            return;
        }

        string directory = Path.Combine(ctx.WorkingDirectory, directoryToMoveTo);

        if (!Directory.Exists(directory) || directory.EndsWith('.'))
        {
            logger.PrintError($"Directory {directory} does not exist");
            return;
        }

        ctx.WorkingDirectory = Path.GetFullPath(directory);
    }

    public void PrintHelp() => Console.WriteLine("cd [dir]: Changes current working directory to specified 'dir'. If 'dir' is '..', changes directory to parent directory");
}