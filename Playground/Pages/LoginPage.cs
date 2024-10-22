using Microsoft.Playwright;
using Playground.Components;
using Playground.Config;

namespace Playground.Pages;

public class LoginPage(IPage page) : BasePage(page)
{
    private readonly TextFieldsComponent _textFields = new(page);
    private readonly ButtonComponent _button = new(page);

    public override async Task NavigateAsync()
    {
        await Page.GotoAsync($"{ConfigSettings.LoadConfig().BaseUrl}/login");
    }

    public async Task LoginAsync(string email, string password)
    {
        await _textFields.FillByPlaceholderAsync("Email", email);
        await _textFields.FillByPlaceholderAsync("Password", password);
        await _button.ClickByTextAsync("Sign in");
    }
}
