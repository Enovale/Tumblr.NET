using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Blocks;

namespace TumblrNET.Models.Common.Undocumented.Conversations
{
    public class TextMessage : Message
    {
        [JsonPropertyName("message")]
        public required string Message { get; set; }
    
        [JsonPropertyName("content")]
        public required Block[] Content { get; set; }
    }
}