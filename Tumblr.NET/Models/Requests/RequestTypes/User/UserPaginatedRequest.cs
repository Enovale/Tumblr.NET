using TumblrNET.Attributes;

namespace TumblrNET.Models.Requests.RequestTypes.User
{
    public abstract class UserPaginatedRequest : UserRequest, IPaginatedRequest
    {
        [UriParamName("limit")]
        public int? Limit { get; set; }
        
        [UriParamName("offset")]
        public int? Offset { get; set; }

        public UserPaginatedRequest(int? limit = null, int? offset = null)
        {
            Limit = limit;
            Offset = offset;
        }
    }
}