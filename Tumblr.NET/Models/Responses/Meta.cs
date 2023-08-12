using System.Net;
using System.Text.Json.Serialization;

namespace TumblrNET.Models.Responses
{
    public class Meta
    {
        [JsonPropertyName("status")]
        public required HttpStatusCode Status { get; set; }
        
        [JsonPropertyName("msg")]
        public required string Message { get; set; }
    }
}