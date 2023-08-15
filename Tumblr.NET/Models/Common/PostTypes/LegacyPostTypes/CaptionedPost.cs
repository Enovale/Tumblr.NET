using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.PostTypes.LegacyPostTypes
{
    public class CaptionedPost : Post
    {
        [JsonPropertyName("caption")]
        public required string Caption { get; set; }
    }
}