using System.Text.Json.Serialization;
using TumblrNET.Models.Responses.ResponseTypes;

namespace TumblrNET.Models.Responses
{
    public class ResponseWrapper<TResponse> where TResponse : Response
    {
        [JsonPropertyName("meta")]
        public required Meta Meta { get; set; }
        
        [JsonPropertyName("response")]
        public required TResponse Response { get; set; }
    }
}