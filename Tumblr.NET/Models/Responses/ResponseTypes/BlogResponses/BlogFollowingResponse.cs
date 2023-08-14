using System.Text.Json.Serialization;
using TumblrNET.Models.Common.BlogTypes;

namespace TumblrNET.Models.Responses.ResponseTypes.BlogResponses
{
    public class BlogFollowingResponse : Response
    {
        [JsonPropertyName("blogs")]
        public required ShortBlog[] Blogs { get; set; }
        
        [JsonPropertyName("total_blogs")]
        public required int TotalBlogs { get; set; }

        internal override void SetClient(Tumblr client)
        {
            foreach (var shortBlog in Blogs)
            {
                shortBlog.SetClient(client);
            }
        }
    }
}