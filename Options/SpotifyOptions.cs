using System.ComponentModel.DataAnnotations;

namespace Bot.Options;

public class SpotifyOptions
{
    [Required]
    public  string ClientId { get; set; }
    [Required]
    public  string ClientSecret { get; set; }
}
