using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;

namespace TumblrNET.Models.Responses.ResponseTypes.UserResponses
{
    public class UserLimit
    {
        [JsonPropertyName("description")]
        public required string Description { get; set; }
        
        /// <summary>
        /// Almost always is measured in days.
        /// </summary>
        [JsonPropertyName("limit")]
        public required int Limit { get; set; }
        
        [JsonPropertyName("remaining")]
        public required int Remaining { get; set; }
        
        [JsonPropertyName("reset_at")]
        [JsonConverter(typeof(JsonTimestampConverter))]
        public required DateTimeOffset ResetAt { get; set; }
    }
}