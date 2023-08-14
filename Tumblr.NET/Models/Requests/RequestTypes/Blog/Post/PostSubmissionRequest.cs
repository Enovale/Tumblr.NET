using TumblrNET.Attributes;
using TumblrNET.Converters.Uri;
using TumblrNET.Models.Common.PostTypes;

namespace TumblrNET.Models.Requests.RequestTypes.Blog.Post
{
    public class PostSubmissionRequest : PostRequest
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.OAuth;
        
        protected override string PostApiPath => "/submission";
        
        [UriParamName("offset")]
        public int? Offset { get; set; }
        
        [UriParamName("filter")]
        [UriParamConverter(typeof(UriAttributeEnumConverter<PostFormat>))]
        public PostFormat? Format { get; set; }
        
        public PostSubmissionRequest(string blogIdentifier, int? offset = null, PostFormat? format = null) : base(blogIdentifier)
        {
            Offset = offset;
            Format = format;
        }
    }
}