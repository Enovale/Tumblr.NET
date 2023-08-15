using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;
using TumblrNET.Models.Common.PostTypes;

namespace TumblrNET.Models.Common.Blocks
{
    // Completely fucking undocumented as always
    public class PollBlock : Block
    {
        [JsonPropertyName("client_id")]
        public required Guid ClientId { get; set; }
        
        [JsonPropertyName("question")]
        public required string Question { get; set; }
        
        [JsonPropertyName("answers")]
        public required PollAnswer[] Answers { get; set; }
        
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(JsonGmtStringConverter))]
        public required DateTime CreatedAt { get; set; }
        
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(JsonTimestampConverter))]
        public required DateTimeOffset Timestamp { get; set; }
    }
}