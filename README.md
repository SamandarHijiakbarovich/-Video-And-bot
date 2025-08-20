# 🎧 Telegram Media Bot

A powerful and scalable Telegram bot built with .NET 8, designed to fetch and deliver media content from multiple sources including **Pexels**, **Spotify**, and **Jamendo**. The bot supports image, video, and music search with clean architecture, modular design, and CI/CD-ready deployment.

---

## 🚀 Features

- 📸 **Photo Search** — Fetch high-quality images from Pexels
- 🎬 **Video Search** — Browse and download videos from Pexels
- 🎵 **Music Discovery** — Search and stream music from Jamendo and Spotify
- 🧠 **Smart Menu Handling** — Context-aware message routing and command parsing
- 🛠️ **Modular Monolithic Architecture** — Clean separation of concerns with scalable structure
- 🔄 **CI/CD Ready** — GitHub Actions and Docker support for automated deployment
- 📦 **API Integration** — Fully compliant with licensing and privacy policies

---

## 🧱 Tech Stack

| Layer              | Technology         |
|-------------------|--------------------|
| Language           | C# (.NET 8)        |
| Bot Framework      | Telegram.Bot       |
| HTTP Clients       | HttpClientFactory  |
| Configuration      | IOptions pattern   |
| Deployment         | Docker, GitHub Actions |
| Architecture       | Modular Monolith + Clean Principles |

---

## ⚙️ Configuration

Create an `appsettings.json` file in the root directory:

```json
{
  "BotKey": "YOUR_TELEGRAM_BOT_TOKEN",
  "Pexels": {
    "ApiKey": "PEXELS_API_KEY",
    "BaseUrl": "https://api.pexels.com"
  },
  "Spotify": {
    "ClientId": "SPOTIFY_CLIENT_ID",
    "ClientSecret": "SPOTIFY_CLIENT_SECRET"
  },
  "Jamendo": {
    "ClientId": "JAMENDO_CLIENT_ID"
  }
}
