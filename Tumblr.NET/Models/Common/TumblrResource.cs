namespace TumblrNET.Models.Common
{
    public abstract class TumblrResource
    {
        protected Tumblr Client { get; set; } = null!;

        internal virtual void SetClient(Tumblr client) => Client = client;
    }
}