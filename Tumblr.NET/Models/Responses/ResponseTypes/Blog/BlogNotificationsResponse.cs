using System.Text.Json.Serialization;
using TumblrNET.Models.Common.ActivityTypes;

namespace TumblrNET.Models.Responses.ResponseTypes.Blog
{
    // TODO Activity wrapper is basically entirely unimplemented.
    // Requires OAuth 2.0 to access.
    public class BlogNotificationsResponse : Response
    {
        [JsonPropertyName("notifications")]
        public required Activity[] Notifications { get; set; }
    }
}