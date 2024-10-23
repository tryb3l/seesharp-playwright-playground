using Microsoft.Playwright;
using Playground.Config;
using Playground.Factories;
using Playground.Helpers;
using Playground.Services;
using Serilog;

namespace Playground.Base;

public class BaseTest
{
    protected IPage Page;
    protected IBrowser Browser;
    protected ILogger Logger;
    protected ConfigSettings? Config;
    protected NavigationService NavigationService;

    [SetUp]
    public async Task Setup()
    {
        Logger = Log.Logger;
        var config = ConfigSettings.LoadConfig();

        var playwright = await Playwright.CreateAsync();
        Browser = await playwright[config.Browser].LaunchAsync(new BrowserTypeLaunchOptions { Headless = config.Headless });

        var contextOptions = new BrowserNewContextOptions();

        var testCategories = TestContext.CurrentContext.Test.Properties["Category"];
        bool runAsSignedInUser = testCategories.Contains("SignedIn");

        if (runAsSignedInUser)
        {
            if (!File.Exists("auth.json"))
            {
                Logger.Information("No existing authentication state found. Registering new user via API.");

                var userFactory = new UserFactory();
                string email = $"testUser_{Guid.NewGuid()}@example.com";
                string password = "password123";

                var token = await userFactory.CreateUserAsync(email, password);

                await AuthHelper.SaveAuthTokenAsync(token);
            }
            else
            {
                Logger.Information("Using existing authentication state from auth.json.");
            }
            contextOptions.StorageStatePath = "auth.json";
        }
        else
        {
            Logger.Information("Running test as not signed-in user.");
        }
        var context = await Browser.NewContextAsync(contextOptions);
        Page = await context.NewPageAsync();

        NavigationService = new NavigationService(Page);

        Logger.Information("Browser launched.");

        await NavigationService.GoToHomePageAsync();
    }

    [TearDown]
    public async Task Teardown()
    {
        try
        {
            await Browser.CloseAsync();
            Logger.Information("Browser closed.");
        }
        catch (Exception e)
        {
            Logger.Error(e, "An error occurred during browser teardown.");
            throw;
        }
    }
}