using Microsoft.Playwright;
using Playground.Base;

namespace Playground.Components;

public class HeaderComponent(IPage page) : BaseComponent
{
    private readonly IPage Page = page;

    public async Task ClickSignInAsync()
    {
        try
        {
            Logger.Information("Clicking 'Sign In' element in header");

            await Page.ClickAsync("a[href='/login']");

            Logger.Information("Successfully clicked 'Sign In' element in header");
        }
        catch (Exception e)
        {
            Logger.Error(e, "Failed to click 'Sign In' element in header");
            throw;
        }

    }

    public async Task ClickHomeAsync()
    {
        try
        {
            Logger.Information("Clicking 'Home' element in header");

            await Page.ClickAsync("a[href='/']");

            Logger.Information("Successfully clicked 'Home' element in header");
        }
        catch (Exception e)
        {
            Logger.Error(e, "Failed to click 'Home' element in header");
            throw;
        }

    }

    public async Task ClickSignUpAsync()
    {
        try
        {
            Logger.Information("Clicking 'Sign Up' element in header");

            await Page.ClickAsync("a[href='/register']");

            Logger.Information("Successfully clicked 'Sign Up' element in header");
        }
        catch (Exception e)
        {
            Logger.Error(e, "Failed to click 'Sign Up' element in header");
            throw;
        }
    }
}
