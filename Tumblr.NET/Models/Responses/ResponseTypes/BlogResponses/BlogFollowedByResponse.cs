using System.Text.Json.Serialization;

namespace TumblrNET.Models.Responses.ResponseTypes.BlogResponses
{
    public class BlogFollowedByResponse : Response
    {
        [JsonPropertyName("followed_by")]
        public bool FollowedBy { get; set; }
    }
}