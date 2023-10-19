using Telegram.Bot.Types;
using Telegram.Bot;

namespace Bot.Handlers;

public partial class BotUpdateHandler
{
    public async Task LenguageUpdateAsync(
       ITelegramBotClient botClient,
       Message update,
       CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(update.Chat.Id,
            "Tilni tanlang",
            cancellationToken: cancellationToken);

    }
    public async Task LenguageEditAsync(
          ITelegramBotClient botClient,
          Message update,
          CancellationToken cancellationToken)
    {
        await LanguageHandler(botClient, update, cancellationToken);
        await botClient.SendTextMessageAsync(update.Chat.Id,
            "Xizmatdan Foydalanganiz uchun Raxmat!",
            cancellationToken: cancellationToken);
    }
}
