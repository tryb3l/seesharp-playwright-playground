using Serilog;

namespace Playground.Config;

public class TestSetup
{
    [OneTimeSetUp]
    public void GlobalSetup()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        Log.Logger = Log.Logger;
    }

    [OneTimeTearDown]
    public void GlobalTeardown()
    {
        Log.CloseAndFlush();
    }
}
