using Microsoft.Playwright;

namespace Playground.Components;

public class ButtonComponent(IPage page) : BaseComponent
{
    private readonly IPage Page = page;

    public async Task ClickBySelectorAsync(string selector)
    {
        try
        {
            Logger.Information("Clicking button with selector '{Selector}'", selector);
            await Page.ClickAsync(selector);
            Logger.Information("Successfully clicked button with selector '{Selector}'", selector);
        }
        catch (Exception e)
        {
            Logger.Error(e, "Failed to click button with selector '{Selector}'", selector);
            throw;
        }
    }

    public async Task ClickByTextAsync(string buttonText)
    {
        try
        {
            Logger.Information("Clicking button with text '{ButtonText}'", buttonText);
            await Page.ClickAsync($"text='{buttonText}'");
            Logger.Information("Successfully clicked button with text '{ButtonText}'", buttonText);
        }
        catch (Exception e)
        {
            Logger.Error(e, "Failed to click button with text '{ButtonText}'", buttonText);
            throw;
        }
    }

    public async Task ClickByRoleAsync(string role, string name)
    {
        await Page.GetByRole(Enum.Parse<AriaRole>(role), new() { Name = name }).ClickAsync();
    }
}
