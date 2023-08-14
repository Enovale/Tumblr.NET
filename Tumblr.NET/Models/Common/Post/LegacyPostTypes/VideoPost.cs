using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.PostTypes.LegacyPostTypes
{
    public class VideoPost : CaptionedPost
    {
        [JsonPropertyName("width")]
        public required int VideoWidth { get; set; }

        [JsonPropertyName("embed_code")]
        public required string EmbedHtml { get; set; }
    }
}