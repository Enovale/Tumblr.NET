using TumblrNET.Attributes;

namespace TumblrNET.Models.Requests.RequestTypes.Blog
{
    public class BlogFollowedByRequest : BlogRequest
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.OAuth;

        protected override string BlogApiPath => "/followed_by";
        
        [UriParamName("query")]
        public string Blog { get; set; }
        
        public BlogFollowedByRequest(string blogIdentifier, string blog) : base(blogIdentifier)
        {
            Blog = blog;
        }
    }
}