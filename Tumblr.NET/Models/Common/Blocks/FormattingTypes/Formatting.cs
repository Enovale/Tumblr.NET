using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;

namespace TumblrNET.Models.Common.Blocks.FormattingTypes
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type",
        UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType,
        IgnoreUnrecognizedTypeDiscriminators = true)]
    [JsonDerivedType(typeof(LinkFormatting), "link")]
    [JsonDerivedType(typeof(MentionFormatting), "mention")]
    [JsonDerivedType(typeof(ColorFormatting), "color")]
    public class Formatting
    {
        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("end")]
        public int End { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonAttributeEnumConverter<FormattingType>))]
        public FormattingType Type { get; set; }
    }
}