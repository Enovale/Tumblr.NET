using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Post;

namespace TumblrNET.Models.Common.AttributionTypes
{
    public class PostAttribution : BlogAttribution
    {
        [JsonPropertyName("post")]
        public required PostInfo Post { get; set; }
    }
}