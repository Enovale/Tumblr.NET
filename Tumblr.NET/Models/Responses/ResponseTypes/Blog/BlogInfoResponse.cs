using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Blog;

namespace TumblrNET.Models.Responses.ResponseTypes.Blog
{
    public class BlogInfoResponse : Response
    {
        [JsonPropertyName("blog")]
        public required BlogInfo Blog { get; set; }
    }
}