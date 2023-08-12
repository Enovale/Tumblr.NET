using TumblrNET.Attributes;

namespace TumblrNET.Models.Requests.RequestTypes.Blog.Post
{
    public abstract class PostPaginatedRequest : PostRequest, IPaginatedRequest
    {
        public abstract override AuthenticationRequirement Auth { get; }
        protected abstract override string PostApiPath { get; }
        
        [UriParamName("limit")]
        public int? Limit { get; set; }
        
        [UriParamName("offset")]
        public int? Offset { get; set; }
        
        public PostPaginatedRequest(string blogIdentifier, int? limit = null, int? offset = null) : base(blogIdentifier)
        {
            Limit = limit;
            Offset = offset;
        }
    }
}