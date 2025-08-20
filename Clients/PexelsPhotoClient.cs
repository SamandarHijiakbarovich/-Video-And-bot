using System.Net.Http;
using System.Text.Json;
using Bot.Models.Pexels;
using Microsoft.Extensions.Options;
using Bot.Options;

namespace Bot.Clients;

public class PexelsPhotoClient
{
    private readonly HttpClient _httpClient;
    private readonly PexelsOptions _options;

    public PexelsPhotoClient(HttpClient httpClient, IOptions<PexelsOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
        _httpClient.DefaultRequestHeaders.Add("Authorization", _options.ApiKey);
    }

    public async Task<List<string>> SearchPhotosAsync(string query, CancellationToken cancellationToken = default)
    {
        var url = $"https://api.pexels.com/v1/search?query={query}&per_page=5";
        var response = await _httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonSerializer.Deserialize<PhotoSearchResult>(json);

        return result?.Photos?.Select(p => p.Src?.Medium).Where(u => u != null).ToList() ?? new List<string>();
    }
}
