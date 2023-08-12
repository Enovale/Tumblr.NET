using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Media
{
    public class MediaDescription
    {
        [JsonPropertyName("url")]
        public required string Url { get; set; }
        
        [JsonPropertyName("type")]
        public string? MimeType { get; set; }
        
        [JsonPropertyName("width")]
        public int? Width { get; set; }
        
        [JsonPropertyName("height")]
        public int? Height { get; set; }
        
        /// <summary>
        /// Undocumented.
        /// </summary>
        [JsonPropertyName("hd")]
        public bool? Hd { get; set; }
        
        [JsonPropertyName("original_dimensions_missing")]
        public bool? OriginalDimensionsMissing { get; set; }
        
        [JsonPropertyName("cropped")]
        public bool? Cropped { get; set; }
        
        [JsonPropertyName("has_original_dimensions")]
        public bool? HasOriginalDimensions { get; set; }
    }
}