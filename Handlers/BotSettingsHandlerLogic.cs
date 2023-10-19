using Telegram.Bot.Types;
using Telegram.Bot;

namespace Bot.Handlers;

public partial class BotUpdateHandler
{
    public async Task SozlamalarAsync(
        ITelegramBotClient botClient,
        Message update,
        CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(update.Chat.Id,
            "Hozircha bu xizmatdan foydalana olmaysiz!❌" +
            "iltimos boshqa xizmatlardan foydalanib turing",
            cancellationToken: cancellationToken);

    }
    public async Task SozlamalarUpdateAsync(ITelegramBotClient botClient, Message update, CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(update.Chat.Id,
            "Hozircha bu xizmatdan foydalana olmaysiz!❌",
cancellationToken: cancellationToken);
    }
}
