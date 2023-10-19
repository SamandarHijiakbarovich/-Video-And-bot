using Telegram.Bot.Types;
using Telegram.Bot;
using Bot.Clients;
using SpotifyAPI.Web;

namespace Bot.Handlers;

public partial class BotUpdateHandler
{
    public async Task MusicSearcher(
        ITelegramBotClient botClient,
        Message update,
        CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(update.Chat.Id,
            "Qo'shiq nomini kiriting.",
            cancellationToken: cancellationToken);

    }

    public async Task SearchMusic(ITelegramBotClient botClient,
       Message text,
       CancellationToken cancellationToken)
    {
        var settings = _sptoptions.Value ?? throw new ArgumentNullException(nameof(_sptoptions));
        var spotifyConfig = SpotifyClientConfig.CreateDefault()
        .WithAuthenticator(
            new ClientCredentialsAuthenticator(settings.ClientId, settings.ClientSecret));

        var spotify = new SpotifyClient(spotifyConfig);

        var searchItems = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.All,
            text.Text)
        {
            Limit = 10
        }, cancellationToken);




        if (searchItems.Tracks?.Items?.Count <= 0)
        {
            await botClient.SendTextMessageAsync(text.Chat.Id, "No track found.", cancellationToken: cancellationToken);
        }
        else
        {

            foreach (var track in searchItems.Tracks?.Items)
            {
                await botClient.SendTextMessageAsync(text.Chat.Id, $"{track.ExternalUrls["spotify"]}",
                    cancellationToken: cancellationToken);
                await botClient.SendTextMessageAsync(text.Chat.Id, track.PreviewUrl);
                //await botClient.SendAudioAsync(
                //    chatId: text.Chat.Id,
                //    audio: track.PreviewUrl,
                //    caption: "Qo'shiq nomi: " + track.Name, // Qo'shiqni nomi
                //    duration: track.DurationMs / 1000 // Qo'shiq davomiati (sekundda)
//);
            }
        }
    }

    public async Task DownloadFromYoutube(string Url, ITelegramBotClient bot, long chatId)
    {
        var client = new YoutubeClien();

        var mp3Url = await client.ReturnDownloadLink(Url);

        await bot.SendAudioAsync(
            chatId: chatId,
            audio: InputFile.FromUri(mp3Url));
    }
}
