using System.Text.Json.Serialization;

namespace Bot.Models.Jamendo;

public class JamendoTrackResult
{
    [JsonPropertyName("results")]
    public List<JamendoTrack>? Results { get; set; }
}

public class JamendoTrack
{
    [JsonPropertyName("audio")]
    public string? Audio { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("artist_name")]
    public string? ArtistName { get; set; }
}
