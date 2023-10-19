using System.Text.Json.Serialization;

namespace Bot.Clients;

public  class PexelsPhotoClient
{
    [JsonPropertyName("page")]
    public long Page { get; set; }

    [JsonPropertyName("per_page")]
    public long PerPage { get; set; }

    [JsonPropertyName("photos")]
    public List<Photo> Photos { get; set; }

    [JsonPropertyName("total_results")]
    public long TotalResults { get; set; }

    [JsonPropertyName("next_page")]
    public string NextPage { get; set; }
}
public  class Photo
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("width")]
    public long Width { get; set; }

    [JsonPropertyName("height")]
    public long Height { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("photographer")]
    public string Photographer { get; set; }

    [JsonPropertyName("photographer_url")]
    public string PhotographerUrl { get; set; }

    [JsonPropertyName("photographer_id")]
    public long PhotographerId { get; set; }

    [JsonPropertyName("avg_color")]
    public string AvgColor { get; set; }

    [JsonPropertyName("src")]
    public Src Src { get; set; }

    [JsonPropertyName("liked")]
    public bool Liked { get; set; }

    [JsonPropertyName("alt")]
    public string Alt { get; set; }
}
public  class Src
{
    [JsonPropertyName("original")]
    public string Original { get; set; }

    [JsonPropertyName("large2x")]
    public string Large2X { get; set; }

    [JsonPropertyName("large")]
    public string Large { get; set; }

    [JsonPropertyName("medium")]
    public string Medium { get; set; }

    [JsonPropertyName("small")]
    public string Small { get; set; }

    [JsonPropertyName("portrait")]
    public string Portrait { get; set; }

    [JsonPropertyName("landscape")]
    public string Landscape { get; set; }

    [JsonPropertyName("tiny")]
    public string Tiny { get; set; }
}

