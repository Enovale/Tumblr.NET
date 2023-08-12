using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Blog;

namespace TumblrNET.Models.Responses.ResponseTypes.Blog
{
    public class BlogFollowingResponse : Response
    {
        [JsonPropertyName("blogs")]
        public required ShortBlog[] Blogs { get; set; }
        
        [JsonPropertyName("total_blogs")]
        public required int TotalBlogs { get; set; }
    }
}