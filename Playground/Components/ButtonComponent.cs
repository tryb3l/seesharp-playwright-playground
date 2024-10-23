using Microsoft.Playwright;
using Playground.Base;

namespace Playground.Components;

public class ButtonComponent(IPage page) : BaseComponent
{
    private readonly IPage Page = page;

    public async Task ClickBySelectorAsync(string selector)
    {
        try
        {
            Logger.Information("Clicking element with selector '{Selector}'", selector);

            await Page.ClickAsync(selector);

            Logger.Information("Successfully clicked element with selector '{Selector}'", selector);
        }
        catch (Exception e)
        {
            Logger.Error(e, "Failed to click element with selector '{Selector}'", selector);
            throw;
        }
    }

    public async Task ClickByTextAsync(string elementText)
    {
        try
        {
            Logger.Information("Clicking element with text '{ButtonText}'", elementText);

            await Page.ClickAsync($"text='{elementText}'");

            Logger.Information("Successfully clicked element with text '{ButtonText}'", elementText);
        }
        catch (Exception e)
        {
            Logger.Error(e, "Failed to click element with text '{ElementText}'", elementText);
            throw;
        }
    }

    public async Task ClickByRoleAsync(string role, string name)
    {
        try
        {
            Logger.Information("Clicking element with role '{Role}' and name {Name}", role, name);

            await Page.GetByRole(Enum.Parse<AriaRole>(role), new() { Name = name }).ClickAsync();

            Logger.Information("Successfully clicked an element with role '{Role}' and name {Name}", role, name);
        }
        catch (Exception e)
        {
            Logger.Error(e, "Failed to click element with name '{Name}' and role '{Role}'", name);
        }

    }
}
