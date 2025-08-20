using System.Text.Json.Serialization;

public class PhotoSearchResult
{
    [JsonPropertyName("photos")]
    public List<Photo>? Photos { get; set; }
}

public class Photo
{
    [JsonPropertyName("src")]
    public PhotoSrc? Src { get; set; }
}

public class PhotoSrc
{
    [JsonPropertyName("medium")]
    public string? Medium { get; set; }

    [JsonPropertyName("original")]
    public string? Original { get; set; }

    [JsonPropertyName("large")]
    public string? Large { get; set; }
}