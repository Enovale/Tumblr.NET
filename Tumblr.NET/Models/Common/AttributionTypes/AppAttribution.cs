using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Media;

namespace TumblrNET.Models.Common.AttributionTypes
{
    public class AppAttribution : LinkAttribution
    {
        [JsonPropertyName("app_name")]
        public string? AppName { get; set; }
        
        [JsonPropertyName("display_text")]
        public string? DisplayText { get; set; }
        
        [JsonPropertyName("logo")]
        public MediaDescription? Logo { get; set; }
    }
}