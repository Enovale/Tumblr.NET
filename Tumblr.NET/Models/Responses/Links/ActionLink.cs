using System.Text.Json.Serialization;

namespace TumblrNET.Models.Responses.Links
{
    public class ActionLink : Link
    {
        [JsonPropertyName("method")]
        public required string Method { get; set; }
        
        [JsonPropertyName("query_params")]
        public required Dictionary<string, object> QueryParams { get; set; }
    }
}