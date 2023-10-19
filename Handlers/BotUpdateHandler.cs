using Bot.Options;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Bot.Handlers;

public partial class BotUpdateHandler : IUpdateHandler
{
    private readonly ILogger<BotUpdateHandler> _logger;
    private readonly IOptions<PexelsOptions> _options;
    private readonly IOptions<SpotifyOptions> _sptoptions;
    public BotUpdateHandler(ILogger<BotUpdateHandler> logger,
        IOptions<PexelsOptions> options,
        IOptions<SpotifyOptions> sptoptions)
    {
        _logger = logger;
        _options = options;
        _sptoptions = sptoptions;

    }
    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
       _logger.LogError(exception, exception.Message);
        return Task.CompletedTask;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Incoming message\n From: {update.Message?.From?.Username}\n" +
            $"Text: {update.Message?.Text}");

        var handlers = update.Type switch
        {
            UpdateType.Message => MessageHandlerAsync(botClient, update.Message, cancellationToken),
            UpdateType.InlineQuery => throw new NotImplementedException(),
            UpdateType.ChosenInlineResult => throw new NotImplementedException(),
            UpdateType.CallbackQuery => CallbackQueryHandler(botClient, update.CallbackQuery, cancellationToken),
            UpdateType.EditedMessage => MessageHandlerAsync(botClient, update.EditedMessage, cancellationToken, true),
            _ => throw new ArgumentOutOfRangeException()
        };
        try
        {
            await handlers;
        }
        catch(Exception ex)
        {
            await  HandlePollingErrorAsync(botClient, ex, cancellationToken);
        }
    }

   
}
