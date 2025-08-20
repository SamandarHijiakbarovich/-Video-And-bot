using Bot.Clients;

namespace Bot.Handlers;

public class BotMusicHandler
{
    private readonly SpotifyClient _spotifyClient;
    private readonly JamendoClient _jamendoClient;

    public BotMusicHandler(SpotifyClient spotifyClient, JamendoClient jamendoClient)
    {
        _spotifyClient = spotifyClient;
        _jamendoClient = jamendoClient;
    }

    public async Task<List<string>> GetMusicPreviewsAsync(string query, CancellationToken cancellationToken = default)
    {
        var spotifyPreviews = await _spotifyClient.SearchPreviewLinksAsync(query, cancellationToken);
        var jamendoDownloads = await _jamendoClient.SearchDownloadableTracksAsync(query, cancellationToken);

        return spotifyPreviews.Concat(jamendoDownloads).ToList();
    }
}
