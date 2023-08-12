using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Blocks
{
    public class LinkBlock : PosterBlock
    {
        [JsonPropertyName("url")]
        public required string Url { get; set; }
        
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        
        [JsonPropertyName("author")]
        public string? Author { get; set; }
        
        [JsonPropertyName("site_name")]
        public string? SiteName { get; set; }
        
        [JsonPropertyName("display_url")]
        public string? DisplayUrl { get; set; }
    }
}