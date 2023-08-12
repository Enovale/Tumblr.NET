using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Blocks.LayoutTypes
{
    public class ModeInfo
    {
        [JsonPropertyName("type")]
        public required string Type { get; set; }
    }
}