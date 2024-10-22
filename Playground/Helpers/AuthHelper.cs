using Newtonsoft.Json;
using Playground.Config;
using Serilog;

namespace Playground.Helpers;

public class AuthHelper
{
    private static readonly ILogger Logger = Log.Logger;

    public static async Task SaveAuthTokenAsync(string token)
    {
        var baseURL = ConfigSettings.LoadConfig().BaseUrl;
        var expiration = DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeSeconds();
        var storageState = new
        {
            cookies = new[]
            {
                new
                {
                    name = "jwt",
                    value = token,
                     domain = new Uri(baseURL).Host,
                    path = "/",
                    expires = DateTimeOffset.UtcNow.AddDays(1),
                    httpOnly = false,
                    secure = false,
                    sameSite = "Lax",
                }
            },
            origins = new object[] { }
        };
        var json = JsonConvert.SerializeObject(storageState, Formatting.Indented);
        await File.WriteAllTextAsync("auth.json", json);
        Logger.Information("Token saved to auth.json");
    }

}
