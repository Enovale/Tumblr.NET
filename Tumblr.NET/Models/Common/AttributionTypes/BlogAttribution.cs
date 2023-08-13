using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Blog;

namespace TumblrNET.Models.Common.AttributionTypes
{
    public class BlogAttribution : LinkAttribution
    {
        [JsonPropertyName("blog")]
        public required ShorterBlog Blog { get; set; }

        internal override void SetClient(Tumblr client)
        {
            base.SetClient(client);
            Blog.SetClient(client);
        }
    }
}