using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;

namespace TumblrNET.Models.Authentication
{
    public class OAuth2State
    {
        [JsonPropertyName("access_token")]
        public required string AccessToken { get; set; }
    
        /// <summary>
        /// Can be expected to exist however is not required for implementation reasons.
        /// </summary>
        [JsonPropertyName("expires_in")]
        [JsonConverter(typeof(JsonTimeToLiveConverter))]
        public required DateTimeOffset? ExpirationDate { get; set; }
    
        [JsonPropertyName("token_type")]
        public required string TokenType { get; set; }
    
        [JsonPropertyName("scope")]
        private string _scope { get; set; } = null!;

        public OAuthScope[] Scopes => throw new NotImplementedException();
    
        [JsonPropertyName("refresh_token")]
        public string? RefreshToken { get; set; }
    }
}