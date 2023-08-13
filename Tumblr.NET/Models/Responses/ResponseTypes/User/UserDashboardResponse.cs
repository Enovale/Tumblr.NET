using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Post;

namespace TumblrNET.Models.Responses.ResponseTypes.User
{
    public class UserDashboardResponse : Response
    {
        [JsonPropertyName("posts")]
        public required PostInfo[] Posts { get; set; }

        internal override void SetClient(Tumblr client)
        {
            foreach (var postInfo in Posts)
            {
                postInfo.SetClient(client);
            }
        }
    }
}