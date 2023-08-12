using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Blog;

namespace TumblrNET.Models.Responses.ResponseTypes.Blog
{
    public class BlogFollowerResponse : Response
    {
        [JsonPropertyName("total_users")]
        public required int TotalUsers { get; set; }
        
        [JsonPropertyName("users")]
        public required Follower[] Users { get; set; }
    }
}