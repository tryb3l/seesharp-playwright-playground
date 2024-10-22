using Microsoft.Playwright;

namespace Playground.Components;

public class HeaderComponent(IPage page)
{
    private readonly IPage _page = page;

    public ILocator SignInLink => _page.Locator("a[href='#/login']");
    public ILocator HomeLink => _page.Locator("");
    public ILocator SignUpLink => _page.Locator("");

    public async Task ClickSignInAsync()
    {
        await SignInLink.ClickAsync();
    }

    public async Task ClickHomeAsync()
    {
        await HomeLink.ClickAsync();
    }

    public async Task ClickSignUpAsync()
    {
        await SignUpLink.ClickAsync();
    }
}
