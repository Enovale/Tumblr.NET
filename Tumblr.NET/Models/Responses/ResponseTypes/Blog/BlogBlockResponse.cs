using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Blog;

namespace TumblrNET.Models.Responses.ResponseTypes.Blog
{
    public class BlogBlockResponse : Response
    {
        [JsonPropertyName("blocked_tumblelogs")]
        public required BlogInfo[] BlockedBlogs { get; set; }
    }
}