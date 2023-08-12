using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Blocks.LayoutTypes
{
    public abstract class TruncatableLayout : Layout
    {
        [JsonPropertyName("truncate_after")]
        public int? TruncateAfter { get; set; }
    }
}