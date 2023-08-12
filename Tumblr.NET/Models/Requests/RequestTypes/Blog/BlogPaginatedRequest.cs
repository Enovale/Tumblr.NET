using TumblrNET.Attributes;

namespace TumblrNET.Models.Requests.RequestTypes.Blog
{
    public abstract class BlogPaginatedRequest : BlogRequest, IPaginatedRequest
    {
        public abstract override AuthenticationRequirement Auth { get; }
        
        protected abstract override string BlogApiPath { get; }
        
        [UriParamName("limit")]
        public int? Limit { get; set; }
        
        [UriParamName("offset")]
        public int? Offset { get; set; }
        
        public BlogPaginatedRequest(string blogIdentifier, int? limit = null, int? offset = null) : base(blogIdentifier)
        {
            Limit = limit;
            Offset = offset;
        }
    }
}