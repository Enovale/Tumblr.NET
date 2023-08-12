using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Blocks.LayoutTypes
{
    public class CondensedLayout : TruncatableLayout
    {
        [JsonPropertyName("blocks")]
        public int[]? Blocks { get; set; }
    }
}