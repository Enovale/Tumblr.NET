using System.ComponentModel;
using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;
using TumblrNET.Models.Common.Blocks.FormattingTypes;

namespace TumblrNET.Models.Common.Blocks
{
    public class TextBlock : Block
    {
        [JsonPropertyName("text")]
        public required string Text { get; set; }

        [JsonPropertyName("subtype")]
        [JsonConverter(typeof(JsonAttributeEnumConverter<TextSubtype>))]
        public TextSubtype? Subtype { get; set; }

        [JsonPropertyName("indent_level")]
        [DefaultValue(0)]
        public int? IndentLevel { get; set; }
        
        [JsonPropertyName("formatting")]
        public Formatting[]? FormattingList { get; set; }
    }
}