using Microsoft.Playwright;
using Playground.Components;
using Playground.Config;

namespace Playground.Services;

public class NavigationService(IPage page)
{
    private readonly IPage _page = page;
    private readonly HeaderComponent _headerComponent = new(page);

    public async Task GoToLoginPageAsync()
    {
        await _headerComponent.ClickSignInAsync();
    }

    public async Task GoToHomePageAsync()
    {
        await _page.GotoAsync($"{ConfigSettings.LoadConfig().BaseUrl}/");
    }

    public async Task GoToSignUpPageAsync()
    {
        await _headerComponent.ClickSignUpAsync();
    }
}
