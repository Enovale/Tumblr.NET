using TumblrNET.Attributes;
using TumblrNET.Converters.Uri;
using TumblrNET.Models.Common.Post;

namespace TumblrNET.Models.Requests.RequestTypes.Blog.Post
{
    public class PostDraftRequest : PostRequest
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.OAuth;

        protected override string PostApiPath => "/draft";
        
        [UriParamName("before_id")]
        public long? BeforePostId { get; set; }
        
        [UriParamName("filter")]
        [UriParamConverter(typeof(UriAttributeEnumConverter<PostFormat>))]
        public PostFormat? Format { get; set; }
        
        public PostDraftRequest(string blogIdentifier, long? beforePostId = null, PostFormat? format = null) : base(blogIdentifier)
        {
            BeforePostId = beforePostId;
            Format = format;
        }
    }
}