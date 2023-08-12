using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Post
{
    public class ShortPost
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
    }
}