using System.Text.Json.Serialization;
using TumblrNET.Models.Common.PostTypes;

namespace TumblrNET.Models.Common.Undocumented.Conversations
{
    public class PostMessage : Message
    {
        [JsonPropertyName("post")]
        public required Post Post { get; set; }
    }
}