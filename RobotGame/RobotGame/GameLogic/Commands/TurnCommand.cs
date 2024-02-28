using RobotGame.GameLogic.Common;
using static RobotGame.GameLogic.Common.Enums;

namespace RobotGame.GameLogic.Commands;

internal class TurnCommand : ICommand
{
    public const string Name = "TURN";
    public bool IsValid { get; private set; }
    public Direction Direction { get; private set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="TurnCommand"/> class.
    /// </summary>
    public TurnCommand(string[] args)
    {
        IsValid = false;

        // test input
        if (args == null || args.Length != 1) return;

        // test the direction
        switch (args[0])
        {
            case Constants.North:
                Direction = Enums.Direction.NORTH;
                break;

            case Constants.East:
                Direction = Enums.Direction.EAST;
                break;

            case Constants.South:
                Direction = Enums.Direction.SOUTH;
                break;

            case Constants.West:
                Direction = Enums.Direction.WEST;
                break;

            default:
                return;
        }

        IsValid = true;
    }
}
