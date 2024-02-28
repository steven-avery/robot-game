namespace RobotGame.GameLogic.Commands;

internal class CommandParser
{
    /// <summary>
    /// Process the input string specified in the argument. 
    /// It will extract the command request and pass any arguments into that command.
    /// </summary>
    /// <param name="input">The string to be precessed.</param>
    /// <returns>This method will return the command that was requested in the input string.</returns>
    public static ICommand? Process(string? input)
    {
        if (input == null) return null;

        string[] words = input.Trim().Split(' ');

        if (words.Length == 0) return null;

        var args = words.Take(new Range(1, words.Length)).ToArray();

        return words[0] switch
        {
            PlaceCommand.Name => new PlaceCommand(args),
            TurnCommand.Name => new TurnCommand(args),
            MoveCommand.Name => new MoveCommand(),
            PrintCommand.Name => new PrintCommand(),
            _ => null,
        };
    }
}
