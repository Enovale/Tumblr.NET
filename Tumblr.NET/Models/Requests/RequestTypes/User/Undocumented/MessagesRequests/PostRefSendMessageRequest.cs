using System.Text.Json.Serialization;
using TumblrNET.Models.Common.PostTypes;

namespace TumblrNET.Models.Requests.RequestTypes.User.Undocumented.MessagesRequests
{
    public class PostRefSendMessageRequest : SendMessageRequest
    {
        [JsonPropertyName("context")]
        public required string Context { get; set; }
        
        [JsonPropertyName("post")]
        public required ShortPost Post { get; set; }
    }
}