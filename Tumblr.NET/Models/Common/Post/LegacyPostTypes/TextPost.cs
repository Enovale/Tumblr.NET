using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.PostTypes.LegacyPostTypes
{
    public class TextPost : TitledPost
    {
        [JsonPropertyName("body")]
        public required string Body { get; set; }
    }
}