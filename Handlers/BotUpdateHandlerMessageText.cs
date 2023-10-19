using Telegram.Bot.Types;
using Telegram.Bot;
using System;

namespace Bot.Handlers;

public partial class BotUpdateHandler
{

    public async Task TextProcessing(
       ITelegramBotClient botClient,
       Message? update,
       CancellationToken cancellationToken,
       bool isEdited)
    {
        if (update is null)
            throw new ArgumentNullException(nameof(update));

        switch (update.Text)
        {
            case "/start":
                await LanguageHandler(botClient, update, cancellationToken);
                break;
            case "Video🎥" or "Bидео🎥" or "Video🎥":
                await VideoSearcher(botClient, update, cancellationToken);
                break;
            case "Rasm📷" or "Изображения📷" or "Image📷":
                await PhotoSearcher(botClient, update, cancellationToken);
                break;
            case "Orqaga🔙" or "Назад🔙" or "Back🔙":
                await LanguageHandler(botClient, update, cancellationToken);
                break;
            case "Tilni o'zgartirish👅" or "Сменить язык👅" or "Change language👅":
                await LenguageUpdateAsync(botClient, update, cancellationToken);
                break;
            case "Sozlamalar🛠" or "Настройки🛠" or "Settings🛠":
                await SozlamalarAsync(botClient, update, cancellationToken);
                break;
            case "Musiqa🎼" or "Музыка🎼" or "Music🎼":
                await MusicSearcher(botClient, update, cancellationToken);
                break;
        }

        if(update.ReplyToMessage is not null && update.ReplyToMessage.Text.Contains("Qo'shiq nomini kiriting."))
        {
            await SearchMusic(botClient, update, cancellationToken);
        }


        if (update.ReplyToMessage is not null && update.ReplyToMessage.Text.Contains("xizmatlardan foydalanib turing"))
        {
            await SozlamalarUpdateAsync(botClient, update, cancellationToken);
        }
        if(update.ReplyToMessage is not null && update.ReplyToMessage.Text.Contains("Tilni tanlang"))
        {
            await LenguageEditAsync(botClient, update, cancellationToken);
        }
     
        if (update.ReplyToMessage is not null && update.ReplyToMessage.Text.Contains("Video nomini kiriting."))
        {
            await SearchVideo(botClient, update, cancellationToken);
           
        }
        if(update.ReplyToMessage is not null && update.ReplyToMessage.Text.Contains("Photo nomini kiriting"))
        {
            await SearchPhoto(botClient, update, cancellationToken);
        }
    }
}


