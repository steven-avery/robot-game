using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RobotGame.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var _host = CreateHostBuilder(args).Build();
        var app = _host.Services.GetRequiredService<IApplication>();

        app.Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) => Host
        .CreateDefaultBuilder(args)
        .ConfigureAppConfiguration(configuration =>
        {
            configuration.AddJsonFile("AppSettings.json");
        })
        .ConfigureServices(services =>
        {
            services.AddSingleton<IApplication, Application>();
        });
}