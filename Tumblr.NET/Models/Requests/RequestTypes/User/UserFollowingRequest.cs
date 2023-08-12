namespace TumblrNET.Models.Requests.RequestTypes.User
{
    public class UserFollowingRequest : UserPaginatedRequest
    {
        public override string UserApiPath => "/following";
        
        public UserFollowingRequest(int? limit = null, int? offset = null) : base(limit, offset)
        {
        }
    }
}