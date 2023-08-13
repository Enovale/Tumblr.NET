using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Post;

namespace TumblrNET.Models.Responses.ResponseTypes.Blog
{
    public class BlogLikesResponse : Response
    {
        [JsonPropertyName("liked_posts")]
        public required PostInfo[] LikedPosts { get; set; }
        
        [JsonPropertyName("liked_count")]
        public required int LikedCount { get; set; }

        internal override void SetClient(Tumblr client)
        {
            foreach (var likedPost in LikedPosts)
            {
                likedPost.SetClient(client);
            }
        }
    }
}