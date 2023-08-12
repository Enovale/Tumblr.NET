using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Blocks.FormattingTypes
{
    public class LinkFormatting : Formatting
    {
        [JsonPropertyName("url")]
        public required string Url { get; set; }
    }
}