using Microsoft.Playwright;
using Playground.Config;
using Serilog;

namespace Playground.Base;

public abstract class BasePage(IPage page)
{
    protected readonly IPage? Page = page;
    protected readonly ILogger Logger = Log.Logger;
    protected readonly string BaseUrl = ConfigSettings.LoadConfig().BaseUrl;

    public abstract Task NavigateAsync();
}
