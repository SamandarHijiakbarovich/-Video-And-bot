using Bot.Clients;
using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Bot.Handlers;

public partial class BotUpdateHandler
{
    public async Task PhotoSearcher(ITelegramBotClient botClient, Message update, CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(update.Chat.Id,
            "Photo nomini kiriting",
            cancellationToken:cancellationToken);

    }

    public async Task SearchPhoto(ITelegramBotClient botclient,Message message,CancellationToken cancellationToken)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", _options.Value.ApiKey);
        client.BaseAddress = new Uri(_options.Value.BaseUrl);

        
        var response = await client.GetAsync($"v1/search?query={message.Text}&per_page");

        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        var results = JsonSerializer.Deserialize<PexelsPhotoClient>(jsonString)
            ?? throw new ArgumentException();

        if(results.Photos.Count == 0)
        {
            await botclient.SendTextMessageAsync(chatId:message.Chat.Id,
    text: "Men siz aytgan rasmni topa olmadim" +
    " Xoxlasangiz saytga kirib bir qidirib ko'ring?? ",
    parseMode: ParseMode.MarkdownV2,
    disableNotification: true,
    replyToMessageId: message.MessageId,
    replyMarkup: new InlineKeyboardMarkup(
        InlineKeyboardButton.WithUrl(
            text: "Check sendMessage method",
            url: "https://www.pexels.com/search/")),
    cancellationToken: cancellationToken);
        }

        foreach (var photo in results.Photos)
        {
            if(photo.Width>=10 && photo.Height >= 10)
            {
                var photoUrl = photo.Src.Large2X;
                await botclient.SendPhotoAsync(
                  chatId: message.Chat.Id,
                  photo: InputFile.FromUri(photoUrl));

            }
               
        }
    }
}
