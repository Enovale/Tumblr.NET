using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Blocks.LayoutTypes
{
    public class RowsLayout : TruncatableLayout
    {
        [JsonPropertyName("display")]
        public required DisplayInfo[] Display { get; set; }
    }
}