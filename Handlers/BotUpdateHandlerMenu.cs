using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace Bot.Handlers;

public partial class BotUpdateHandler
{
    public async Task MenuBotUz(
        ITelegramBotClient bot,
        CallbackQuery? message,
        CancellationToken cancellation)
    {

        var replyKeyboard = new ReplyKeyboardMarkup(
            new[]
            {
                new []
                {
                    new KeyboardButton("Sozlamalar🛠"),
                    new KeyboardButton("Tilni o'zgartirsh👅"),
                },
                new []
                {
                    new KeyboardButton("Musiqa🎼"),
                    new KeyboardButton("Video🎥"),
                    
                },
                new[]
                {
                    new KeyboardButton("Orqaga🔙"),
                    new KeyboardButton("Rasm📷")
                }
            })
        {
            ResizeKeyboard = true
        };

        await bot.SendTextMessageAsync(
            chatId: message.From.Id,
            text: "Kerakli bo'limni tanlang:",
            replyMarkup: replyKeyboard,
            cancellationToken: cancellation
        );
    }
    public async Task MenuBotRu(
        ITelegramBotClient bot,
        CallbackQuery? message,
        CancellationToken cancellation)
    {

        var replyKeyboard = new ReplyKeyboardMarkup(
            new[]
            {
                new []
                {
                    new KeyboardButton("Hастройки🛠"),
                    new KeyboardButton("Изменить язык👅"),

                },
                new []
                {
                    new KeyboardButton("Музыка🎼"),
                    new KeyboardButton("Bидео🎥"),

                },
                new[]
                {
                    new KeyboardButton("Назад🔙"),
                    new KeyboardButton("Изображения📷")
                }
            })
        {
            ResizeKeyboard = true
        };

        await bot.SendTextMessageAsync(
            chatId: message.From.Id,
            text: "Выберите нужный раздел",
            replyMarkup: replyKeyboard,
            cancellationToken: cancellation
        );
    }

    public async Task MenuBotEng(
        ITelegramBotClient bot,
        CallbackQuery? message,
        CancellationToken cancellation)
    {

        var replyKeyboard = new ReplyKeyboardMarkup(
            new[]
            {
                new []
                {
                    new KeyboardButton("Settings🛠"),
                    new KeyboardButton("Change language👅"),


                },
                new []
                {
                    new KeyboardButton("Music🎼"),
                    new KeyboardButton("Video🎥"),
                },
                new[]
                {
                    new KeyboardButton("Back🔙"),
                    new KeyboardButton("Image📷")

                }
            })
        {
            ResizeKeyboard = true
        };

        await bot.SendTextMessageAsync(
            chatId: message.From.Id,
            text: "Choose needed section:",
            replyMarkup: replyKeyboard,
            cancellationToken: cancellation
        );

    }


}
