using System.ComponentModel.DataAnnotations;

namespace Bot.Options;

public class PexelsOptions
{
    [Required]
    public  string ApiKey { get; set; }
    [Required]
    public   string BaseUrl { get; set; }
}
