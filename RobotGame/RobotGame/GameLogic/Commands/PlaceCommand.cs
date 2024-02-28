using RobotGame.GameLogic.Common;

namespace RobotGame.GameLogic.Commands;

internal class PlaceCommand : ICommand
{
    public const string Name = "PLACE";
    public bool IsValid { get; private set; }
    public Enums.Direction Direction { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="PlaceCommand"/> class.
    /// </summary>
    public PlaceCommand(string[] args)
    {
        IsValid = false;

        // test input
        if (args == null || args.Length != 3) return;

        // test the X vector
        if (!int.TryParse(args[0], out int resultX))
        {
            return;
        }
        X = resultX;

        // test the Y vector
        if (!int.TryParse(args[1], out int resultY))
        {
            return;
        }
        Y = resultY;

        // test the direction
        switch (args[2])
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
