namespace TumblrNET.Models.Requests.RequestTypes.Blog.Post
{
    public abstract class PostRequest : BlogRequest
    {
        public abstract override AuthenticationRequirement Auth { get; }
        
        protected abstract string PostApiPath { get; }

        protected sealed override string BlogApiPath => $"{ApiPath}/posts{PostApiPath}";
        
        public PostRequest(string blogIdentifier) : base(blogIdentifier)
        {
        }
    }
}