using System.Text.Json.Serialization;
using TumblrNET.Models.Common.AttributionTypes;

namespace TumblrNET.Models.Common.Blocks.LayoutTypes
{
    public class AskLayout : Layout
    {
        [JsonPropertyName("blocks")]
        public required int[] Blocks { get; set; }
        
        [JsonPropertyName("attribution")]
        public BlogAttribution? Attribution { get; set; }
    }
}