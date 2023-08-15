using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Media;

namespace TumblrNET.Models.Common.PostTypes.LegacyPostTypes
{
    public class LinkPost : TitledPost
    {
        [JsonPropertyName("description")]
        public required string Description { get; set; }
        
        [JsonPropertyName("url")]
        public required string LinkUrl { get; set; }
        
        [JsonPropertyName("link_author")]
        public required string LinkAuthor { get; set; }
        
        [JsonPropertyName("excerpt")]
        public required string Excerpt { get; set; }
        
        [JsonPropertyName("publisher")]
        public required string Publisher { get; set; }
        
        [JsonPropertyName("photos")]
        public required LegacyPhoto[] Photos { get; set; }
    }
}