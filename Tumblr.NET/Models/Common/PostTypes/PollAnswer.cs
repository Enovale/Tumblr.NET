using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.PostTypes
{
    public class PollAnswer
    {
        [JsonPropertyName("answer_text")]
        public required string Text { get; set; }
        
        [JsonPropertyName("client_id")]
        public required Guid ClientId { get; set; }
    }
}