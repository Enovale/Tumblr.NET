using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;

namespace TumblrNET.Models.Common.Blog
{
    public class Follower
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        
        [JsonPropertyName("following")]
        public required bool Following { get; set; }
        
        [JsonPropertyName("url")]
        public required string Url { get; set; }
        
        [JsonPropertyName("updated")]
        [JsonConverter(typeof(JsonTimestampConverter))]
        public required DateTimeOffset Updated { get; set; }
    }
}