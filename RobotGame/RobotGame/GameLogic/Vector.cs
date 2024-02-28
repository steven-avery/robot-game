using RobotGame.GameLogic.Common;

namespace RobotGame.GameLogic;

/// <summary>
/// Initialises an instance of the <see cref="Vector"/> class.
/// This is used to hold the position of the player.
/// </summary>
/// <param name="x">The x or row position.</param>
/// <param name="y">The y or column position.</param>
/// <param name="z">The direction the player is facing.</param>
internal class Vector(int x, int y, Enums.Direction z)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    public Enums.Direction Direction { get; set; } = z;
}
