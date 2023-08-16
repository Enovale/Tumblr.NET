using TumblrNET.Attributes;
using TumblrNET.Converters.Uri;
using TumblrNET.Models.Common.PostTypes;

namespace TumblrNET.Models.Requests.RequestTypes.Blog.Post.Queue
{
    public class QueueGetRequest : QueueRequest, IPaginatedRequest
    {
        public override string QueueApiPath => "";

        [UriParamName("filter")]
        [UriParamConverter(typeof(UriAttributeEnumConverter<PostFormat>))]
        public PostFormat? Format { get; set; }

        [UriParamName("limit")]
        public int? Limit { get; set; }
        
        [UriParamName("offset")]
        public int? Offset { get; set; }
        
        public QueueGetRequest(string blogIdentifier, int? limit = null, int? offset = null, PostFormat? format = null) : base(blogIdentifier)
        {
            Limit = limit;
            Offset = offset;
            Format = format;
        }
    }
}