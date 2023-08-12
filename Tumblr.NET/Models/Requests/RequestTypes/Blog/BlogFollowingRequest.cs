namespace TumblrNET.Models.Requests.RequestTypes.Blog
{
    public class BlogFollowingRequest : BlogPaginatedRequest
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.OAuth;
        
        protected override string BlogApiPath => "/following";

        public BlogFollowingRequest(string blogIdentifier, int? limit = null, int? offset = null) : base(blogIdentifier, limit, offset)
        {
        }
    }
}