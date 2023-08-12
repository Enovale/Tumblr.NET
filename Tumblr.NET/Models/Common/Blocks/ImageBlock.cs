using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;
using TumblrNET.Models.Common.AttributionTypes;
using TumblrNET.Models.Common.Media;

namespace TumblrNET.Models.Common.Blocks
{
    public class ImageBlock : PosterBlock
    {
        [JsonPropertyName("media")]
        public required MediaDescription[] Media { get; set; }
        
        [JsonPropertyName("colors")]
        public Dictionary<string, string>? Colors { get; set; }
        
        [JsonPropertyName("feedback_token")]
        public string? FeedbackToken { get; set; }
        
        // TODO Rewrite converter to support arrays
        [JsonPropertyName("attribution")]
        [JsonConverter(typeof(JsonSingleOrArrayConverter<Attribution>))]
        public List<Attribution>? Attribution { get; set; }
        
        [JsonPropertyName("alt_text")]
        public string? AltText { get; set; }
        
        [JsonPropertyName("caption")]
        public string? Caption { get; set; }
    }
}