using TumblrNET.Models.Requests;

namespace TumblrNET
{
    public class TumblrConfiguration
    {
        public string OAuthRoot { get; set; } = "https://tumblr.com";
        
        public string ApiRoot { get; set; } = "https://api.tumblr.com";

        public string UserAgent { get; set; } = "Tumblr.NET";

        public AuthenticationRequirement MaximumAvailableAuthentication
        {
            get
            {
                if (OAuthValid)
                    return AuthenticationRequirement.OAuth;
                
                if (ApiKeyValid && !string.IsNullOrEmpty(ApiKey))
                    return AuthenticationRequirement.ApiKey;

                return AuthenticationRequirement.None;
            }
        }

        public string ApiKey { get; set; }

        public bool ApiKeyValid { get; internal set; } = false;
        
        public string OAuthScheme { get; internal set; }
        
        public string OAuthAccessToken { get; internal set; }

        public bool OAuthValid => false;
    }
}