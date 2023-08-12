using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Blocks
{
    public class AudioBlock : AudioVideoBlock
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        
        [JsonPropertyName("artist")]
        public string? Artist { get; set; }
        
        [JsonPropertyName("album")]
        public string? Album { get; set; }
    }
}