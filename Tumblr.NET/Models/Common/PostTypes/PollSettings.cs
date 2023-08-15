using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;

namespace TumblrNET.Models.Common.PostTypes
{
    public class PollSettings
    {
        [JsonPropertyName("multiple_choice")]
        public required bool MultipleChoice { get; set; }
        
        [JsonPropertyName("close_status")]
        [JsonConverter(typeof(JsonAttributeEnumConverter<PollStatus>))]
        public required PollStatus PollStatus { get; set; }
        
        // TODO Seems to be a datetime offset from the poll timestamp but it's out of scope so IDK how to handle this.
        [JsonPropertyName("expire_after")]
        public required long ExpireAfter { get; set; }
        
        [JsonPropertyName("source")]
        public required string Source { get; set; }
    }
}