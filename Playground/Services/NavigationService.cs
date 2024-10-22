using System;
using Microsoft.Playwright;
using Playground.Pages;

namespace Playground.Services;

public class NavigationService(IPage page)
{
    private readonly IPage _page = page;

    public async Task<T>NavigateToAsync<T>() where T: BasePage
    {
        var pageInstance = (T)Activator.CreateInstance(typeof(T), _page)! ?? throw new InvalidOperationException("Failed to create page instance.");
        await pageInstance.NavigateAsync();
        return pageInstance;
    }
}
