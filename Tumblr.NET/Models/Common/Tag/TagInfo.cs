using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Tag
{
    public class TagInfo
    {
        [JsonPropertyName("tag")]
        public required string Tag { get; set; }
        
        [JsonPropertyName("thumb_url")]
        public string? ThumbnailUrl { get; set; }
        
        [JsonPropertyName("is_tracked")]
        public required bool IsTracked { get; set; }
        
        [JsonPropertyName("featured")]
        public required bool Featured { get; set; }
    }
}