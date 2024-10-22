using Serilog;

namespace Playground.Components;

public class BaseComponent
{
    protected readonly ILogger Logger;

    public BaseComponent()
    {
        Logger = Log.Logger;
    }
}