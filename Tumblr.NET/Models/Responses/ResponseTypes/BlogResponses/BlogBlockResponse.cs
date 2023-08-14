using System.Text.Json.Serialization;
using TumblrNET.Models.Common.BlogTypes;

namespace TumblrNET.Models.Responses.ResponseTypes.BlogResponses
{
    public class BlogBlockResponse : Response
    {
        [JsonPropertyName("blocked_tumblelogs")]
        public required Blog[] BlockedBlogs { get; set; }

        internal override void SetClient(Tumblr client)
        {
            foreach (var blockedBlog in BlockedBlogs)
            {
                blockedBlog.SetClient(client);
            }
        }
    }
}