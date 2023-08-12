using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;
using TumblrNET.Models.Common.Blog;
using TumblrNET.Models.Common.Post;

namespace TumblrNET.Models.Responses.ResponseTypes.User
{
    public class UserInfo
    {
        [JsonPropertyName("following")]
        public required int Following { get; set; }
        
        [JsonPropertyName("default_post_format")]
        [JsonConverter(typeof(JsonAttributeEnumConverter<PostFormat>))]
        public required PostFormat DefaultPostFormat { get; set; }
        
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        
        [JsonPropertyName("likes")]
        public required int Likes { get; set; }
        
        // TODO This is another one of the million shortblog types please define or figure out a better solution
        [JsonPropertyName("blogs")]
        public required ShortBlog[] Blogs { get; set; }
    }
}