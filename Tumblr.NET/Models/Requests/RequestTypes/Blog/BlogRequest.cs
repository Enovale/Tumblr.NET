namespace TumblrNET.Models.Requests.RequestTypes.Blog
{
    public abstract class BlogRequest : Request
    {
        public abstract override AuthenticationRequirement Auth { get; }

        protected abstract string BlogApiPath { get; }

        public sealed override string ApiPath => $"/v2/blog/{BlogIdentifier}{BlogApiPath}";

        public string BlogIdentifier { get; set; }

        public BlogRequest(string blogIdentifier)
        {
            BlogIdentifier = blogIdentifier;
        }
    }
}