using System.Reflection;
using System.Text.RegularExpressions;
using Mash.Application.Commands;
using Mash.Infrastructure;

namespace Mash.CommandLine;

internal static partial class Program
{
    private static string[] _input = [];
    private static readonly Logger Logger = new();
    
    private static void Main()
    {
        string userRootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        
        List<ICommand> commands = [];
        CommandContext ctx = new CommandContext(userRootDirectory, userRootDirectory, commands);

        ctx.RegisteredCommands.AddRange(
            Assembly.GetAssembly(typeof(ICommand))!
                .GetTypes()
                .Where(type => typeof(ICommand).IsAssignableFrom(type))
                .Where(type => type is { IsClass: true, IsAbstract: false })
                .Select(type => (ICommand)Activator.CreateInstance(type, ctx, Logger)!)
        );
        
        Console.WriteLine("""
                          Mash (Malo Shell) v0.0.1
                          
                          Type 'help' for help (duh)
                          
                          """);
        
        Run(ctx);
    }

    private static void Run(CommandContext ctx)
    {
        while (true)
        {
            _input = GetInput();

            if (_input.Length == 0) continue;
            
            ICommand? command = ctx.RegisteredCommands.FirstOrDefault(c => c.Name == _input[0]);

            if (command is null)
            {
                Logger.PrintError($"Unrecognized Command \"{_input[0]}\". Type 'help' for a list of available commands");
                continue;
            }
            
            if (_input.Length - 1 >= command.MinParameterCount)
                command.Execute(_input);
            else
                Logger.PrintError($"Command \"{command.Name}\" needs at least {command.MinParameterCount} parameters.");
        }
    }

    private static string[] GetInput()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("~ ");
        Console.ResetColor();
        Console.Write("> ");
        string? input = Console.ReadLine();

        if (input == null) return [];
        
        string[] parsedInput = Parse(input);
        return parsedInput;

    }

    private static string[] Parse(string input)
    {
        MatchCollection matches = InputRegex().Matches(input);

        return matches
            .Select(m => m.Groups[1].Success ? m.Groups[1].Value : m.Groups[2].Value)
            .ToArray();
    }

    [GeneratedRegex("""(?:"([^"]*)"|(\S+))""")]
    private static partial Regex InputRegex();
}