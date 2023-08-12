using System.Drawing;
using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;

namespace TumblrNET.Models.Common.Blocks.FormattingTypes
{
    public class ColorFormatting : Formatting
    {
        [JsonPropertyName("hex")]
        [JsonConverter(typeof(JsonColorConverter))]
        public Color Color { get; set; }
    }
}