namespace TumblrNET.Models.Requests.RequestTypes.Blog
{
    public class BlogInfoRequest : BlogRequest
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.ApiKey;
        
        protected override string BlogApiPath => "/info";

        public BlogInfoRequest(string blogIdentifier) : base(blogIdentifier)
        {
        }
    }
}