using Bot;
using Bot.Clients;
using Bot.Handlers;
using Bot.Options;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Polling;

const string BotKeyConfigKey = "BotKey";
const string PexelsConfigKey = "Pexels";
const string SpotifyConfigKey = "Spotify";
const string JamendoConfigKey = "Jomendo";

var builder = WebApplication.CreateBuilder(args);

// 🔐 Load Telegram bot token from configuration
var token = builder.Configuration.GetValue<string>(BotKeyConfigKey);
if (string.IsNullOrWhiteSpace(token))
    throw new InvalidOperationException("Telegram bot token is missing in configuration.");

builder.Services.AddSingleton<ITelegramBotClient>(_ => new TelegramBotClient(token));

// ⚙️ Load external API options from appsettings.json
builder.Services.Configure<PexelsOptions>(builder.Configuration.GetSection(PexelsConfigKey));
builder.Services.Configure<SpotifyOptions>(builder.Configuration.GetSection(SpotifyConfigKey));
builder.Services.Configure<JomendoOptions>(builder.Configuration.GetSection(JamendoConfigKey));

// 🌐 Register HTTP clients for external APIs
builder.Services.AddHttpClient<PexelsPhotoClient>();
builder.Services.AddHttpClient<PexelsVideoClient>();
builder.Services.AddHttpClient<JamendoClient>();

// 🎵 Register media clients and handlers
builder.Services.AddSingleton<SpotifyClient>();
builder.Services.AddSingleton<BotMusicHandler>();
builder.Services.AddSingleton<BotPhotoHandler>();
builder.Services.AddSingleton<BotVideoHandler>();

// 🤖 Register Telegram bot update handler and background service
builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();
builder.Services.AddHostedService<BotBackgroundService>();

var app = builder.Build();
app.Run();
