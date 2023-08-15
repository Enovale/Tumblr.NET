using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Undocumented.Conversations;

namespace TumblrNET.Models.Responses.ResponseTypes.UserResponses.Undocumented
{
    // Undocumented.
    public class MessagesResponse : Response
    {
        [JsonPropertyName("messages")]
        public required Message[] Message { get; set; }
    }
}