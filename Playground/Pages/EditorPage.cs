
using Microsoft.Playwright;
using Playground.Components;
using Playground.Config;

namespace Playground.Pages;

public class EditorPage(IPage page) : BasePage(page)
{

    private readonly TextFieldsComponent _textFields = new(page);
    private readonly ButtonComponent _buttonComponent = new(page);

    public override async Task NavigateAsync()
    {
        await Page.GotoAsync($"{ConfigSettings.LoadConfig().BaseUrl}/#/editor");
    }

    public async Task CreateArticleAsync(string title, string body, string description, string tags)
    {
        await _textFields.FillByPlaceholderAsync("Article Title", title);
        await _textFields.FillByPlaceholderAsync("What's this article about?", description);
        await _textFields.FillByPlaceholderAsync("Write your article (in markdown)", body);
        await _textFields.FillByPlaceholderAsync("Enter tags", tags);
        await _buttonComponent.ClickByTextAsync("Publish Article");
    }
}
