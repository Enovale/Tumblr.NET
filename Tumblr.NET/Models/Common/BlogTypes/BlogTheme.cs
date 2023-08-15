using System.Drawing;
using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;
using TumblrNET.Models.Common.Blocks;

namespace TumblrNET.Models.Common.BlogTypes
{
    public class BlogTheme
    {
        [JsonPropertyName("avatar_shape")]
        [JsonConverter(typeof(JsonAttributeEnumConverter<AvatarShape>))]
        public required AvatarShape AvatarShape { get; set; }
        
        [JsonPropertyName("background_color")]
        public required string BackgroundColor { get; set; }
        
        [JsonPropertyName("body_font")]
        public required string BodyFont { get; set; }
        
        [JsonPropertyName("header_bounds")]
        public required string HeaderBounds { get; set; }
        
        [JsonPropertyName("header_image")]
        public string? HeaderImage { get; set; }
        
        [JsonPropertyName("header_image_npf")]
        public ImageBlock? HeaderImageNpf { get; set; }
        
        [JsonPropertyName("header_image_focused")]
        public required string HeaderImageFocused { get; set; }
        
        [JsonPropertyName("header_image_poster")]
        public required string HeaderImagePoster { get; set; }
        
        [JsonPropertyName("header_image_scaled")]
        public required string HeaderImageScaled { get; set; }
        
        [JsonPropertyName("header_stretch")]
        public required bool HeaderStretch { get; set; }
        
        [JsonPropertyName("link_color")]
        [JsonConverter(typeof(JsonColorConverter))]
        public required Color LinkColor { get; set; }
        
        [JsonPropertyName("show_avatar")]
        public required bool ShowAvatar { get; set; }
        
        [JsonPropertyName("show_description")]
        public required bool ShowDescription { get; set; }
        
        [JsonPropertyName("show_header_image")]
        public required bool ShowHeaderImage { get; set; }
        
        [JsonPropertyName("show_title")]
        public required bool ShowTitle { get; set; }
        
        [JsonPropertyName("title_color")]
        [JsonConverter(typeof(JsonColorConverter))]
        public required Color TitleColor { get; set; }
        
        [JsonPropertyName("title_font")]
        public required string TitleFont { get; set; }
        
        [JsonPropertyName("title_font_weight")]
        public required string TitleFontWeight { get; set; }
    }
}