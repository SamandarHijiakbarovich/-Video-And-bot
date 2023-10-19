using Bot.Handlers;
using Bot;
using Telegram.Bot.Polling;
using Telegram.Bot;
using Bot.Options;

const string BotKeyConfigKey = "BotKey";
const string ApiKeyConfigKey = "Pexels";
const string SpotifyConfigKey = "Spotify";

var builder = WebApplication.CreateBuilder(args);

var token = builder.Configuration.GetValue(BotKeyConfigKey, "");
builder.Services.Configure<PexelsOptions>(builder.Configuration.GetSection(ApiKeyConfigKey));
builder.Services.Configure<SpotifyOptions>(builder.Configuration.GetSection(SpotifyConfigKey));
builder.Services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(token!));
builder.Services.AddHostedService<BotBackgroundService>();
builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();

var app = builder.Build();



app.Run();
