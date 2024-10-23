using System.Net.Http.Json;
using Playground.Config;
using Serilog;

namespace Playground.Factories;

public class UserFactory
{
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    public UserFactory()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri(ConfigSettings.LoadConfig().BaseUrl) };
        _logger = Log.Logger;
    }

    public async Task<string> CreateUserAsync(string email, string password)
    {
        var payload = new
        {
            user = new
            {
                username = email.Split('@')[0],
                email = email,
                password = password
            }
        };

        try
        {
            _logger.Information("Creating user via API with email '{Email}'", email);

            var response = await _httpClient.PostAsJsonAsync("/api/users", payload);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<dynamic>();
            string token = content!.user.token;

            _logger.Information("User created and token received");
            return token;
        }
        catch (Exception e)
        {
            _logger.Error(e, "Failed to create user via API.");
            throw;
        }
    }

    public async Task<string> LoginUserAsync(string email, string password)
    {
        var payload = new
        {
            user = new
            {
                email = email,
                password = password
            }
        };
        try
        {
            _logger.Information("Logging in user via API with email '{Email}'", email);

            var response = await _httpClient.PostAsJsonAsync("/api/users/login", payload);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<dynamic>();
            string token = content!.user.token;

            _logger.Information("User logged in and token received");

            return token;
        }
        catch (Exception e)
        {
            _logger.Error(e, "Failed to log in user via API");
            throw;
        }
    }
}