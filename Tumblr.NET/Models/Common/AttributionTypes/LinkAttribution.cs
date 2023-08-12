using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.AttributionTypes
{
    public class LinkAttribution : Attribution
    {
        [JsonPropertyName("url")]
        public required string Url { get; set; }
    }
}