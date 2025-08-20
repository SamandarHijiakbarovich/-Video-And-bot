using Bot.Clients;

public class BotPhotoHandler
{
    private readonly PexelsPhotoClient _photoClient;

    public BotPhotoHandler(PexelsPhotoClient photoClient)
    {
        _photoClient = photoClient;
    }

    public Task<List<string>> GetPhotoUrlsAsync(string query, CancellationToken cancellationToken = default)
        => _photoClient.SearchPhotosAsync(query, cancellationToken);
}