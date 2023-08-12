using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Blog;

namespace TumblrNET.Models.Common.AttributionTypes
{
    public class BlogAttribution : LinkAttribution
    {
        [JsonPropertyName("blog")]
        public required ShortBlog Blog { get; set; }
    }
}