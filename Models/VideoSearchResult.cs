using System.Text.Json.Serialization;

namespace Bot.Models.Pexels;

public class VideoSearchResult
{
    [JsonPropertyName("videos")]
    public List<Video>? Videos { get; set; }
}

public class Video
{
    [JsonPropertyName("video_files")]
    public List<VideoFile>? VideoFiles { get; set; }
}

public class VideoFile
{
    [JsonPropertyName("link")]
    public string? Link { get; set; }

    [JsonPropertyName("quality")]
    public string? Quality { get; set; }

    [JsonPropertyName("file_type")]
    public string? FileType { get; set; }
}
