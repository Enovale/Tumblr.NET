using System.Text.Json.Serialization;

namespace TumblrNET.Models.Responses
{
    public class TumblrError
    {
        [JsonPropertyName("title")]
        public required string Title { get; set; }
    
        [JsonPropertyName("code")]
        public required int ErrorCode { get; set; }
    
        [JsonPropertyName("detail")]
        public required string Detail { get; set; }
    }
}