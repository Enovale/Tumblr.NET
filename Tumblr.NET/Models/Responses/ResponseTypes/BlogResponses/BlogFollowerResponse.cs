using System.Text.Json.Serialization;
using TumblrNET.Models.Common.BlogTypes;

namespace TumblrNET.Models.Responses.ResponseTypes.BlogResponses
{
    public class BlogFollowerResponse : Response
    {
        [JsonPropertyName("total_users")]
        public required int TotalUsers { get; set; }
        
        [JsonPropertyName("users")]
        public required Follower[] Users { get; set; }

        internal override void SetClient(Tumblr client)
        {
            foreach (var follower in Users)
            {
                follower.SetClient(client);
            }
        }
    }
}