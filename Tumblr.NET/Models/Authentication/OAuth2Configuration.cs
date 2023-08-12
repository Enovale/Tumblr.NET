namespace TumblrNET.Models.Authentication
{
    public class OAuth2Configuration
    {
        public required string ClientId { get; set; }
        
        public required string ClientSecret { get; set; }
        
        public required OAuthScope[] Scopes { get; set; }
        
        public required string RedirectUrl { get; set; }
        
        internal string? State { get; set; }
        
        internal string? AuthScheme { get; set; }
        
        internal string? AccessToken { get; set; }
        
        internal DateTimeOffset? ExpirationTime { get; set; }
        
        internal string? RefreshToken { get; set; }
    }
}