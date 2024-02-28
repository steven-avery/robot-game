namespace RobotGame.GameLogic;

internal class Board(int rows, int columns) : IBoard
{
    public int Rows { get; private set; } = rows;
    public int Columns { get; private set; } = columns;
    public IPlayer Player { get; set; }

    /// <summary>
    /// Adds a player to the game.
    /// </summary>
    /// <param name="player">The player to add.</param>
    public void AddPlayer(IPlayer player)
    {
        if (player == null) return;

        if (Player != null) return;

        Player = player;
    }
}
