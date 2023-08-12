using TumblrNET.Attributes;

namespace TumblrNET.Models.Requests.RequestTypes.User
{
    public class UserLikesRequest : UserPaginatedRequest
    {
        public override string UserApiPath => "/likes";
        
        [UriParamName("before")]
        public DateTimeOffset? Before { get; set; }
        
        [UriParamName("after")]
        public DateTimeOffset? After { get; set; }
        
        public UserLikesRequest(int? limit = null, int? offset = null, DateTimeOffset? before = null, DateTimeOffset? after = null) : base(limit, offset)
        {
            Before = before;
            After = after;
        }
    }
}