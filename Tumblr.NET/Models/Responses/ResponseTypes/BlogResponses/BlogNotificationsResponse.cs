using System.Text.Json.Serialization;
using TumblrNET.Models.Common.ActivityTypes;

namespace TumblrNET.Models.Responses.ResponseTypes.BlogResponses
{
    // TODO Activity wrapper is basically entirely unimplemented.
    // Requires OAuth 2.0 to access.
    public class BlogNotificationsResponse : Response
    {
        [JsonPropertyName("notifications")]
        public required Activity[] Notifications { get; set; }

        internal override void SetClient(Tumblr client)
        {
            foreach (var notification in Notifications)
            {
                notification.SetClient(client);
            }
        }
    }
}