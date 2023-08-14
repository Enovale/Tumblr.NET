using System.Text.Json.Serialization;
using TumblrNET.Models.Common.BlogTypes;

namespace TumblrNET.Models.Common.Blocks.FormattingTypes
{
    public class MentionFormatting : Formatting
    {
        [JsonPropertyName("blog")]
        public required BlogMention Blog { get; set; }
    }
}