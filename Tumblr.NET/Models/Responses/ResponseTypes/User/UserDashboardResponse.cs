using System.Text.Json.Serialization;
using TumblrNET.Models.Common.PostTypes;

namespace TumblrNET.Models.Responses.ResponseTypes.UserResponses
{
    public class UserDashboardResponse : Response
    {
        [JsonPropertyName("posts")]
        public required Post[] Posts { get; set; }

        internal override void SetClient(Tumblr client)
        {
            foreach (var postInfo in Posts)
            {
                postInfo.SetClient(client);
            }
        }
    }
}