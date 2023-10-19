using Telegram.Bot.Types;
using Telegram.Bot;
using Bot.Clients;
using System.Text.Json;

namespace Bot.Handlers;

public partial class BotUpdateHandler
{
    public async Task VideoSearcher(
        ITelegramBotClient botClient,
        Message update,
        CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(update.Chat.Id,
            "Video nomini kiriting.",
            cancellationToken: cancellationToken);

    }

    public async Task SearchVideo(
           ITelegramBotClient botClient,
           Message update,
           CancellationToken cancellationToken)
    {
        var client = new HttpClient();

        client.DefaultRequestHeaders.Add("Authorization", _options.Value.ApiKey);
        client.BaseAddress = new Uri(_options.Value.BaseUrl);


        var response = await client.GetAsync($"videos/search?query={update.Text}&per_page=50");

        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        var results = JsonSerializer.Deserialize<PexelsVideoClient>(jsonString)
            ?? throw new ArgumentException();

        if(results.videos.Count==0)
        {
            await botClient.SendTextMessageAsync(update.Chat.Id,
                "Bunday video topilmadi.",
                cancellationToken: cancellationToken);
            return;
        }

        foreach (var video in results.videos)
        { 
            if(video.width>=10 && video.height >= 360 )
            {
                var videoFile = video.video_files.First(vf =>vf.width>=12 && 
                vf.height>=360 && vf.file_type == "video/mp4" && 
                ( vf.quality=="hd" || vf.quality=="sd" || vf.quality=="uhd"));
                if (videoFile is not null)
                {
                    var videoUri = new Uri(videoFile.link);

                    await botClient.SendVideoAsync(
                        chatId: update.Chat.Id,
                        video: InputFile.FromUri(videoUri),
                        supportsStreaming: true,
                        cancellationToken: cancellationToken
                    );
                }
            }
        }


    }
}
