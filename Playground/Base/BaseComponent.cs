using Serilog;

namespace Playground.Base;

public class BaseComponent
{
    protected readonly ILogger Logger;

    public BaseComponent()
    {
        Logger = Log.Logger;
    }
}