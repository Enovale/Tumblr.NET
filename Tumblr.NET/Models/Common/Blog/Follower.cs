using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;

namespace TumblrNET.Models.Common.Blog
{
    public class Follower : TumblrResource
    {
        [JsonPropertyName("name")]
        public required string Username { get; set; }
        
        [JsonPropertyName("following")]
        public required bool Following { get; set; }
        
        [JsonPropertyName("url")]
        public required string Url { get; set; }
        
        [JsonPropertyName("updated")]
        [JsonConverter(typeof(JsonTimestampConverter))]
        public required DateTimeOffset Updated { get; set; }

        public BlogInfo RetrieveBlog() => Client.GetBlogInfo(Username);
    }
}