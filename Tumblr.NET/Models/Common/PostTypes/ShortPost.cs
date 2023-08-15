using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;

namespace TumblrNET.Models.Common.PostTypes
{
    public class ShortPost : TumblrResource
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(JsonTimestampConverter))]
        public DateTimeOffset? Timestamp { get; set; }
        
        [JsonPropertyName("blog")]
        public string? BlogUuid { get; set; }

        public Post RetrieveFullPost()
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}