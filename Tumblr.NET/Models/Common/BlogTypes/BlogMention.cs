using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.BlogTypes
{
    public class BlogMention
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        
        [JsonPropertyName("url")]
        public required string Url { get; set; }
        
        [JsonPropertyName("uuid")]
        public required string Uuid { get; set; }
    }
}