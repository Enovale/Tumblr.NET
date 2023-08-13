using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Blog
{
    public class ShorterBlog : TumblrResource
    {
        [JsonPropertyName("name")]
        public required string Username { get; set; }
    
        [JsonPropertyName("url")]
        public required string Url { get; set; }
    
        [JsonPropertyName("uuid")]
        public required string Uuid { get; set; }

        public BlogInfo RetrieveFullBlog() => Client.GetBlogInfo(Username);
    }
}