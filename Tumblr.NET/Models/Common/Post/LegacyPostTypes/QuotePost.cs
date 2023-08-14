using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.PostTypes.LegacyPostTypes
{
    public class QuotePost : Post
    {
        [JsonPropertyName("text")]
        public required string Text { get; set; }
        
        [JsonPropertyName("source")]
        public required string Source { get; set; }
    }
}