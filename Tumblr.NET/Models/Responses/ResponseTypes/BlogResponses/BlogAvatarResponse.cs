using System.Text.Json.Serialization;

namespace TumblrNET.Models.Responses.ResponseTypes.BlogResponses
{
    public class BlogAvatarResponse : Response
    {
        [JsonPropertyName("avatar_url")]
        public required string AvatarUrl { get; set; }
    }
}