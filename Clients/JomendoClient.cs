using System.Net.Http;
using System.Text.Json;
using Bot.Models.Jamendo;
using Microsoft.Extensions.Options;
using Bot.Options;

namespace Bot.Clients;

public class JamendoClient
{
    private readonly HttpClient _httpClient;
    private readonly JomendoOptions _options;

    public JamendoClient(HttpClient httpClient, IOptions<JomendoOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<List<string>> SearchDownloadableTracksAsync(string query, CancellationToken cancellationToken = default)
    {
        var url = $"https://api.jamendo.com/v3.0/tracks/?client_id={_options.ClientId}&format=json&limit=5&search={query}&include=musicinfo&audioformat=mp31";
        var response = await _httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonSerializer.Deserialize<JamendoTrackResult>(json);

        return result?.Results?.Select(t => t.Audio)?.Where(a => !string.IsNullOrEmpty(a)).ToList() ?? new List<string>();
    }
}
