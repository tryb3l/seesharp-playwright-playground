using Newtonsoft.Json;

namespace Playground.Config;
public class ConfigSettings
{
    public required string Browser { get; set; }
    public required string BaseUrl { get; set; }
    public bool Headless { get; set; }

    private static ConfigSettings? _config;

    public static ConfigSettings LoadConfig()
    {
        if (_config == null)
        {
            var baseDirectory = AppContext.BaseDirectory;
            var projectRoot = (Directory.GetParent(baseDirectory)?.Parent?.Parent?.Parent?.FullName) ?? throw new InvalidOperationException("Project root directory could not be determined.");
            var configPath = Path.Combine(projectRoot, "Config", "appsettings.json");
            var configText = File.ReadAllText(configPath);
            _config = JsonConvert.DeserializeObject<ConfigSettings>(configText);
        }
        return _config!;
    }
}