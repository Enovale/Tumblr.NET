namespace TumblrNET.Models.Requests.RequestTypes.Blog
{
    public class BlogFollowersRequest : BlogPaginatedRequest
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.OAuth;
        
        protected override string BlogApiPath => "/followers";
        
        public BlogFollowersRequest(string blogIdentifier, int? limit = null, int? offset = null) : base(blogIdentifier, limit, offset)
        {
        }
    }
}