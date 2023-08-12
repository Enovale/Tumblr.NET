using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Media
{
    public class LegacyPhotos
    {
        [JsonPropertyName("caption")]
        public required string Caption { get; set; }
        
        [JsonPropertyName("original_size")]
        public MediaDescription? OriginalSize { get; set; }
        
        [JsonPropertyName("alt_sizes")]
        public required MediaDescription[] AltSizes { get; set; }
    }
}