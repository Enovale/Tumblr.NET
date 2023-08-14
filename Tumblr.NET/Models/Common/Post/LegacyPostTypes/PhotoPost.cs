using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Media;

namespace TumblrNET.Models.Common.PostTypes.LegacyPostTypes
{
    public class PhotoPost : CaptionedPost
    {
        [JsonPropertyName("width")]
        public required int Width { get; set; }
        
        [JsonPropertyName("height")]
        public required int Height { get; set; }
        
        [JsonPropertyName("photos")]
        public required LegacyPhoto[] Photos { get; set; }
    }
}