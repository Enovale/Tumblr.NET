using System.Text.Json.Serialization;

namespace TumblrNET.Models.Responses.ResponseTypes.Blog
{
    public class BlogAvatarResponse : Response
    {
        [JsonPropertyName("avatar_url")]
        public required string AvatarUrl { get; set; }
    }
}