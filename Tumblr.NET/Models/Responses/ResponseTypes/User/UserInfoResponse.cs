using System.Text.Json.Serialization;

namespace TumblrNET.Models.Responses.ResponseTypes.User
{
    public class UserInfoResponse : Response
    {
        [JsonPropertyName("user")]
        public required UserInfo User { get; set; }

        internal override void SetClient(Tumblr client)
        {
            User.SetClient(client);
        }
    }
}