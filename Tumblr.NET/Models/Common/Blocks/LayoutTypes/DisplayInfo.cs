using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Blocks.LayoutTypes
{
    public class DisplayInfo
    {
        [JsonPropertyName("blocks")]
        public required int[] Blocks { get; set; }
        
        [JsonPropertyName("mode")]
        public ModeInfo? Mode { get; set; }
    }
}