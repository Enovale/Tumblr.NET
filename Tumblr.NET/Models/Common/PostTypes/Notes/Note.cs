using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;
using TumblrNET.Models.Common.BlogTypes;

namespace TumblrNET.Models.Common.PostTypes.Notes
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(LikeNote), "like")]
    [JsonDerivedType(typeof(ReblogNote), "reblog")]
    public abstract class Note : TumblrResource
    {
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(JsonTimestampConverter))]
        public required DateTimeOffset Timestamp { get; set; }
        
        [JsonPropertyName("blog_name")]
        public required string BlogName { get; set; }
        
        [JsonPropertyName("blog_uuid")]
        public required string BlogUuid { get; set; }
        
        [JsonPropertyName("blog_url")]
        public required string BlogUrl { get; set; }
        
        [JsonPropertyName("followed")]
        public required bool Followed { get; set; }
        
        [JsonPropertyName("avatar_shape")]
        [JsonConverter(typeof(JsonAttributeEnumConverter<AvatarShape>))]
        public required AvatarShape AvatarShape { get; set; }

        public Blog RetrieveBlog() => Client.GetBlog(BlogName);
    }
}