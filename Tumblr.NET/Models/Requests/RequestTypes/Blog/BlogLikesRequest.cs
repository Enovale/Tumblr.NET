using TumblrNET.Attributes;
using TumblrNET.Converters.Uri;

namespace TumblrNET.Models.Requests.RequestTypes.Blog
{
    public class BlogLikesRequest : BlogPaginatedRequest
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.ApiKey;

        protected override string BlogApiPath => "/likes";
        
        [UriParamName("before")]
        [UriParamConverter(typeof(UriTimestampConverter))]
        public DateTimeOffset? Before { get; set; }
        
        [UriParamName("after")]
        [UriParamConverter(typeof(UriTimestampConverter))]
        public DateTimeOffset? After { get; set; }


        public BlogLikesRequest(string blogIdentifier, int? limit = null, int? offset = null,
            DateTimeOffset? before = null, DateTimeOffset? after = null) : base(blogIdentifier, limit, offset)
        {
            Before = before;
            After = after;
        }
    }
}