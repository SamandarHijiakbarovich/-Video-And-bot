using System.Net.Http;
using System.Text.Json;
using Bot.Models.Pexels;
using Microsoft.Extensions.Options;
using Bot.Options;

namespace Bot.Clients;

public class PexelsVideoClient
{
    private readonly HttpClient _httpClient;
    private readonly PexelsOptions _options;

    public PexelsVideoClient(HttpClient httpClient, IOptions<PexelsOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
        _httpClient.DefaultRequestHeaders.Add("Authorization", _options.ApiKey);
    }

    public async Task<List<string>> SearchVideosAsync(string query, CancellationToken cancellationToken = default)
    {
        var url = $"https://api.pexels.com/videos/search?query={query}&per_page=5";
        var response = await _httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonSerializer.Deserialize<VideoSearchResult>(json);

        return result?.Videos?.Select(v => v.VideoFiles?.FirstOrDefault()?.Link).Where(l => l != null).ToList() ?? new List<string>();
    }
}
