using Microsoft.Playwright;
using Playground.Base;

namespace Playground.Factories;

public class PageFactory(IPage page)
{
    private readonly IPage _page = page;

    public T GetPage<T>() where T : BasePage
    {
        return (T)Activator.CreateInstance(typeof(T), _page)! ?? throw new InvalidOperationException("Failed to create page instance.");
    }
}
