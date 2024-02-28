using Microsoft.Extensions.Configuration;
using RobotGame.GameLogic;

namespace RobotGame.Services;

internal class Application(IConfiguration configuration) : IApplication
{
    /// <summary>
    /// Initial run point for the application, and the game.
    /// </summary>
    public void Run()
    {
        var game = new Game(configuration);

        game.PlacePlayer();
        game.Play();
    }
}
