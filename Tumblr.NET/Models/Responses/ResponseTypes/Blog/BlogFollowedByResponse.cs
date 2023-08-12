using System.Text.Json.Serialization;

namespace TumblrNET.Models.Responses.ResponseTypes.Blog
{
    public class BlogFollowedByResponse : Response
    {
        [JsonPropertyName("followed_by")]
        public bool FollowedBy { get; set; }
    }
}