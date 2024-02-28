namespace RobotGame.GameLogic.Commands;

/// <summary>
/// Initialises a new instance of the <see cref="PrintCommand"/> class.
/// </summary>
internal class PrintCommand : ICommand
{
    public const string Name = "PRINT";
    public bool IsValid => true;
}
