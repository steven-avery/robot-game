using RobotGame.GameLogic.Common;

namespace RobotGame.GameLogic;

internal interface IPlayer
{
    Vector Position { get; }
    void Move(int x, int y);
    void Turn(Enums.Direction direction);
}
