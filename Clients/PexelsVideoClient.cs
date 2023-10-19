namespace Bot.Clients;

public class PexelsVideoClient
{
    public int page { get; set; }
    public int per_page { get; set; }
    public List<Video> videos { get; set; }
    public int total_results { get; set; }
    public string next_page { get; set; }
    public string url { get; set; }
}

public class Video
{
    public int id { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public int duration { get; set; }
    public object full_res { get; set; }
    public List<object> tags { get; set; }
    public string url { get; set; }
    public string image { get; set; }
    public object avg_color { get; set; }
    public User user { get; set; }
    public List<VideoFile> video_files { get; set; }
    public List<VideoPicture> video_pictures { get; set; }
}

public class User
{
    public int id { get; set; }
    public string name { get; set; }
    public string url { get; set; }
}

public class VideoFile
{
    public int id { get; set; }
    public string quality { get; set; }
    public string file_type { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public double? fps { get; set; }
    public string link { get; set; }
}
public class VideoPicture
{
    public int id { get; set; }
    public int nr { get; set; }
    public string picture { get; set; }
}




