namespace TumblrNET.Models.Requests.RequestTypes.Blog
{
    public class BlogBlockRequest : BlogPaginatedRequest
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.OAuth;

        protected override string BlogApiPath => "/blocks";
        
        public BlogBlockRequest(string blogIdentifier, int? limit = null, int? offset = null) : base(blogIdentifier, limit, offset)
        {
        }
    }
}