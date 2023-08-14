using System.Text.Json.Serialization;

namespace TumblrNET.Models.Responses.ResponseTypes.UserResponses
{
    public class UserLimitResponse : Response
    {
        [JsonPropertyName("user")]
        public required Dictionary<string, UserLimit> Limits { get; set; }
    }
}