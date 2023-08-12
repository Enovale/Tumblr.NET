using System.Drawing;
using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;

namespace TumblrNET.Models.Common.Blocks.Paywall
{
    public abstract class ColorPaywallBlock : TextPaywallBlock
    {
        [JsonPropertyName("color")]
        [JsonConverter(typeof(JsonColorConverter))]
        public Color? Color { get; set; }
    }
}