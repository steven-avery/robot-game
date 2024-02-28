using RobotGame.GameLogic.Common;

namespace RobotGame.GameLogic;

internal class Player(Vector vector) : IPlayer
{
    public Vector Position { get; set; } = vector;

    /// <summary>
    /// Move the player.
    /// </summary>
    /// <param name="x">The new row vector position.</param>
    /// <param name="y">The new column vector position.</param>
    public void Move(int x, int y)
    {
        Position.X = x;
        Position.Y = y;
    }

    /// <summary>
    /// Turn the player.
    /// </summary>
    /// <param name="direction">The new direction to turn to.</param>
    public void Turn(Enums.Direction direction)
    {
        Position.Direction = direction;
    }
}
