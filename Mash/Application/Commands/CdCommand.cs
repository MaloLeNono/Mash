namespace Mash.Application.Commands;

public class CdCommand(CommandContext ctx) : Command
{
    public override int MinParameterCount => 0;
    public override string Name => "cd";

    public override void Execute(string[] input)
    {
        if (input.Length > 2)
        {
            Logger.PrintError("'cd' command only takes 1 argument");
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
                Logger.PrintError("There is no higher directory");
                return;
            }

            ctx.WorkingDirectory = parentDirectory.FullName;

            return;
        }

        string directory = Path.Combine(ctx.WorkingDirectory, directoryToMoveTo);

        if (!Directory.Exists(directory) || directory.EndsWith('.'))
        {
            Logger.PrintError($"Directory {directory} does not exist");
            return;
        }

        ctx.WorkingDirectory = Path.GetFullPath(directory);
    }

    public override void PrintHelp() => Console.WriteLine("cd [dir]: Changes current working directory to specified 'dir'. If 'dir' is '..', changes directory to parent directory");
}