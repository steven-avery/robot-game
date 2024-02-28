namespace RobotGame.GameLogic.Commands;

internal interface ICommand
{
    bool IsValid { get; }
}
