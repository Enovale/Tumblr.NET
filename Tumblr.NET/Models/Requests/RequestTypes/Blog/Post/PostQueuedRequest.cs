using TumblrNET.Attributes;
using TumblrNET.Converters.Uri;
using TumblrNET.Models.Common.Post;

namespace TumblrNET.Models.Requests.RequestTypes.Blog.Post
{
    public class PostQueuedRequest : PostPaginatedRequest
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.OAuth;
        
        protected override string PostApiPath => "/queue";
        
        [UriParamName("filter")]
        [UriParamConverter(typeof(UriAttributeEnumConverter<PostFormat>))]
        public PostFormat? Format { get; set; }
        
        public PostQueuedRequest(string blogIdentifier, int? limit = null, int? offset = null, PostFormat? format = null) : base(blogIdentifier, limit, offset)
        {
            Format = format;
        }
    }
}