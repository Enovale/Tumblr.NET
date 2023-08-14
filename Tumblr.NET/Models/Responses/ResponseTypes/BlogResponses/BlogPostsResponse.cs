using System.Text.Json.Serialization;
using TumblrNET.Models.Common.PostTypes;

namespace TumblrNET.Models.Responses.ResponseTypes.BlogResponses
{
    public class BlogPostsResponse : BlogInfoResponse
    {
        [JsonPropertyName("posts")]
        public required Post[] Posts { get; set; }
        
        [JsonPropertyName("total_posts")]
        public int TotalPosts { get; set; }

        internal override void SetClient(Tumblr client)
        {
            foreach (var postInfo in Posts)
            {
                postInfo.SetClient(client);
            }
        }
    }
}