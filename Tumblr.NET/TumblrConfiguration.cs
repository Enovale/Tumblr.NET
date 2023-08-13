namespace TumblrNET
{
    public class TumblrConfiguration
    {
        public string OAuthRoot { get; set; } = "https://www.tumblr.com";
        
        public string ApiRoot { get; set; } = "https://api.tumblr.com";

        public string UserAgent { get; set; } = "Tumblr.NET";
    }
}