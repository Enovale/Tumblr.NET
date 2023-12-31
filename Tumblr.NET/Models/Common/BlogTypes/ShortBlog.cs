using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;
using TumblrNET.Models.Common.Media;

namespace TumblrNET.Models.Common.BlogTypes
{
    // TODO There are literally like 8 different definitions across the API
    // determining what a "short blog info" is. This will probably be handled
    // by just making everything nullable by I FUCKING HATE IT SO MUCH.
    public class ShortBlog : TumblrResource
    {
        [JsonPropertyName("name")]
        public required string Username { get; set; }
        
        [JsonPropertyName("title")]
        public required string Title { get; set; }
        
        [JsonPropertyName("description")]
        public required string Description { get; set; }
        
        [JsonPropertyName("url")]
        public required string Url { get; set; }
        
        [JsonPropertyName("uuid")]
        public required string Uuid { get; set; }
        
        [JsonPropertyName("avatar")]
        public MediaDescription[]? Avatars { get; set; }
        
        [JsonPropertyName("updated")]
        [JsonConverter(typeof(JsonTimestampConverter))]
        public required DateTimeOffset Updated { get; set; }
        
        // Undocumented. Is only null during UserInfo requests.
        [JsonPropertyName("tumblrmart_accessories")]
        public TumblrmartAccessories? TumblrmartAccessories { get; set; }
        
        // Undocumented. Is only null during UserInfo requests.
        [JsonPropertyName("can_show_badges")]
        public bool? CanShowBadges { get; set; }
        
        // Undocumented.
        [JsonPropertyName("active")]
        public bool? Active { get; set; }
        
        // Undocumented.
        [JsonPropertyName("show_follow_action")]
        public bool? ShowFollowAction { get; set; }

        public Blog RetrieveFullBlog() => Client.GetBlog(Username);
    }
}