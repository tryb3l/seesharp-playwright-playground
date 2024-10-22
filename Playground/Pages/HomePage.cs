using Microsoft.Playwright;
using Playground.Components;

namespace Playground.Pages;

public class HomePage(IPage page) : BasePage(page)
{
    public HeaderComponent Header { get; } = new HeaderComponent(page);

    public override async Task NavigateAsync()
    {
        if (Page != null)
        {
            await Page.GotoAsync(BaseUrl);
        }
        else
        {
            throw new InvalidOperationException("Page is null.");
        }
    }
}
