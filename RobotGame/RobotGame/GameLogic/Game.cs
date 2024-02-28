using Microsoft.Extensions.Configuration;
using RobotGame.GameLogic.Commands;
using RobotGame.GameLogic.Common;

namespace RobotGame.GameLogic;

internal class Game
{
    private readonly Board Board;

    /// <summary>
    /// Initialises a new instance of the <see cref="Game"/> class.
    /// This class is used to control the overall game logic.
    /// </summary>
    /// <param name="configuration">App configuration from the app settings.</param>
    public Game(IConfiguration configuration)
    {
        var rows = configuration.GetValue<int>("boardSize:rows");
        var columns = configuration.GetValue<int>("boardSize:columns");

        Board = new Board(rows, columns);
    }

    /// <summary>
    /// Game loop for placing the player.
    /// </summary>
    public void PlacePlayer()
    {
        var placingPlayer = true;

        Console.WriteLine("Please enter instruction:");

        do
        {
            var command = ReadUserInputAndParseCommand();

            if (command is null || !command.IsValid)
            {
                DisplayInvalidInstructionError();
                continue;
            }

            switch (command.GetType().Name)
            {
                case nameof(PlaceCommand):
                    if (PlaceCommandExecutedOk((PlaceCommand)command))
                    { 
                        placingPlayer = false; 
                    }
                    break;

                default:
                    DisplayPlaceError();
                    break;
            }
        } while (placingPlayer);
    }

    /// <summary>
    /// Game loop for playing the game.
    /// </summary>
    public void Play()
    {
        while (true)
        {
            var command = ReadUserInputAndParseCommand();

            if (command is null || !command.IsValid)
            {
                DisplayInvalidInstructionError();
                continue;
            }

            switch (command.GetType().Name)
            {
                case nameof(TurnCommand):
                    ExecuteTurnCommand((TurnCommand)command);
                    break;

                case nameof(MoveCommand):
                    ExecuteMoveCommand();
                    break;

                case nameof(PrintCommand):
                    ExecutePrintCommand();
                    break;

                default:
                    DisplayInvalidInstructionError();
                    break;
            }
        }
    }

    private static ICommand? ReadUserInputAndParseCommand()
    {
        var userInput = Console.ReadLine();
        var command = CommandParser.Process(userInput);

        return command;
    }

    private static void DisplayPlaceError() => Console.WriteLine("Error: First instruction must be PLACE");
    private static void DisplayInvalidInstructionError() => Console.WriteLine("Invalid Instruction");
    private static void DisplayStopGoingToFallError() => Console.WriteLine("Stop! Going to fall!");

    private bool PlaceCommandExecutedOk(PlaceCommand command)
    {
        if (command.X < 0 || command.X > Board.Rows - 1 || command.Y < 0 || command.Y > Board.Columns - 1)
        {
            DisplayInvalidInstructionError();
            return false;
        }

        var vector = new Vector(command.X, command.Y, command.Direction);
        Board.AddPlayer(new Player(vector));

        return true;
    }

    private void ExecuteTurnCommand(TurnCommand command)
    {
        Board.Player.Turn(command.Direction);
    }

    private void ExecuteMoveCommand()
    {
        Vector position = Board.Player.Position;

        int row = position.X;
        int column = position.Y;

        switch (position.Direction)
        {
            case Enums.Direction.NORTH:
                row++;
                break;

            case Enums.Direction.SOUTH:
                row--;
                break;

            case Enums.Direction.WEST:
                column--;
                break;

            case Enums.Direction.EAST:
                column++;
                break;
        }

        if (row < 0 || row > Board.Rows - 1 || column < 0 || column > Board.Columns - 1)
        {
            DisplayStopGoingToFallError();
            return;
        }

        Board.Player.Move(row, column);
    }

    private void ExecutePrintCommand()
    {
        var position = Board.Player.Position;
        Console.WriteLine($"{position.X} {position.Y} {position.Direction}");
    }
}
