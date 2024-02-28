namespace RobotGame.GameLogic.Commands;

internal class MoveCommand : ICommand
{
    public const string Name = "MOVE";
    public bool IsValid { get; private set; }

    /// <summary>
    /// Initialises a new instance of the <see cref="MoveCommand"/> class.
    /// </summary>
    public MoveCommand()
    {
        IsValid = true;
    }
}
