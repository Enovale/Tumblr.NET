using System.Text.Json.Serialization;
using TumblrNET.Models.Common.PostTypes;

namespace TumblrNET.Models.Common.AttributionTypes
{
    public class PostAttribution : BlogAttribution
    {
        [JsonPropertyName("post")]
        public required ShortPost Post { get; set; }

        internal override void SetClient(Tumblr client)
        {
            base.SetClient(client);
            Post.SetClient(client);
        }
    }
}