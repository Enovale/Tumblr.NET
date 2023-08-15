using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Undocumented.Conversations
{
    // Undocumented.
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(PostMessage), "POSTREF")]
    [JsonDerivedType(typeof(TextMessage), "TEXT")]
    public class Message
    {
        [JsonPropertyName("ts")]
        public required DateTimeOffset Timestamp { get; set; }
        
        [JsonPropertyName("participant")]
        public required string ParticipantUuid { get; set; }
    }
}