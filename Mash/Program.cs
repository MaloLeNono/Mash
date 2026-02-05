using System.Text.RegularExpressions;
using Mash.Application;
using Mash.Application.Commands;

namespace Mash;

internal static partial class Program
{
    private static CommandContext? _ctx;
    
    private static void Main()
    {
        string userRootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string[] input;

        List<Command> commands = [];
        _ctx = new CommandContext(userRootDirectory, userRootDirectory, commands);
        
        _ctx.RegisteredCommands.AddRange([
            new ClearCommand(),
            new ListCommand(_ctx),
            new CdCommand(_ctx),
            new PwdCommand(_ctx),
            new HelpCommand(_ctx),
            new EchoCommand(),
            new MakeDirCommand(_ctx)
        ]);
        
        Console.WriteLine("""
                          Mash (Malo Shell) v0.0.1
                          
                          Type 'help' for help (duh)
                          
                          """);
        
        bool running = true;
        
        while (running)
        {
            input = GetInput();

            if (input.Length == 0) continue;
            
            if (input[0] == "exit" && input.Length == 1)
                running = false;
            
            Command? command = _ctx.RegisteredCommands.FirstOrDefault(c => c.Name == input[0]);

            if (command is null)
            {
                Logger.PrintError($"Unrecognized Command \"{input[0]}\". Type 'help' for a list of available commands");
                continue;
            }
            
            if (input.Length - 1 >= command.MinParameterCount)
                command.Execute(input);
            else
                Logger.PrintError($"Command \"{command.Name}\" needs at least {command.MinParameterCount} parameters.");
        }
    }

    private static string[] GetInput()
    {
        if (_ctx is null) return [];
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"{_ctx.WorkingDirectory} ");
        Console.ResetColor();
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