using Bot.Options;
using Microsoft.Extensions.Options;
using SpotifyAPI.Web;

public class SpotifyClient
{
    private readonly SpotifyOptions _options;
    private readonly SpotifyAPI.Web.SpotifyClient _spotify;

    public SpotifyClient(IOptions<SpotifyOptions> options)
    {
        _options = options.Value;

        var config = SpotifyClientConfig.CreateDefault()
            .WithAuthenticator(new ClientCredentialsAuthenticator(_options.ClientId, _options.ClientSecret));

        _spotify = new SpotifyAPI.Web.SpotifyClient(config);
    }

    public async Task<List<string>> SearchPreviewLinksAsync(string query, CancellationToken cancellationToken = default)
    {
        var result = await _spotify.Search.Item(new SearchRequest(SearchRequest.Types.Track, query)
        {
            Limit = 5
        }, cancellationToken);

        return result.Tracks?.Items?
            .Where(t => !string.IsNullOrEmpty(t.PreviewUrl))
            .Select(t => t.PreviewUrl)
            .ToList() ?? new List<string>();
    }
}