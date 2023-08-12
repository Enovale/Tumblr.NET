using System.Text.Json.Serialization;
using TumblrNET.Models.Common.AttributionTypes;
using TumblrNET.Models.Common.Media;

namespace TumblrNET.Models.Common.Blocks
{
    // TODO This name sucks
    public abstract class AudioVideoBlock : PosterBlock
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }
        
        [JsonPropertyName("media")]
        public MediaDescription? Media { get; set; }
        
        [JsonPropertyName("provider")]
        public string? Provider { get; set; }
        
        [JsonPropertyName("embed_html")]
        public string? EmbedHtml { get; set; }
        
        [JsonPropertyName("embed_url")]
        public string? EmbedUrl { get; set; }
        
        [JsonPropertyName("metadata")]
        public object? Metadata { get; set; }
        
        [JsonPropertyName("attribution")]
        public Attribution? Attribution { get; set; }
    }
}