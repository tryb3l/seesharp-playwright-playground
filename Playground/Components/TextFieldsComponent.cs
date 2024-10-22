using Microsoft.Playwright;
using Serilog;
using Serilog.Core;

namespace Playground.Components;

public class TextFieldsComponent(IPage page) : BaseComponent
{
    private readonly IPage Page = page;

    public async Task FillByPlaceholderAsync(string placeholder, string text)
    {
        try
        {
            Logger.Information("Filling input with placeholder '{Placeholder}'", placeholder);
            await Page.FillAsync($"[placeholder='{placeholder}']", text);
            Logger.Information("Successfully filled input with placeholder '{Placeholder}'", placeholder);
        }
        catch (Exception e)
        {
            Logger.Error(e, "Failed to fill input with placeholder '{Placeholder}'", placeholder);
            throw;
        }
    }

    public async Task FillBySelectorAsync(string selector, string text)
    {
        try
        {
            Logger.Information("Filling input with selector '{Selector}'", selector);
            await Page.FillAsync(selector, text);
            Logger.Information("Successfully filled input with selector '{Selector}'", selector);
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Failed to fill input with selector '{Selector}'", selector);
            throw;
        }
    }

    public async Task FillByLabelAsync(string labelText, string text)
    {
        try
        {
            Logger.Information("Filling input with label '{LabelText}'", labelText);
            await Page.FillAsync($"label:text('{labelText}') + input", text);
            Logger.Information("Successfully filled input with label '{LabelText}'", labelText);
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Failed to fill input with label '{LabelText}'", labelText);
            throw;
        }
    }
}