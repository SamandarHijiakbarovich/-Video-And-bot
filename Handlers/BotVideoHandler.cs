using Bot.Clients;

public class BotVideoHandler
{
    private readonly PexelsVideoClient _videoClient;

    public BotVideoHandler(PexelsVideoClient videoClient)
    {
        _videoClient = videoClient;
    }

    public Task<List<string>> GetVideoUrlsAsync(string query, CancellationToken cancellationToken = default)
        => _videoClient.SearchVideosAsync(query, cancellationToken);
}