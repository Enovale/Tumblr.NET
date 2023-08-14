using TumblrNET.Attributes;
using TumblrNET.Converters.Uri;
using TumblrNET.Models.Common.PostTypes;

namespace TumblrNET.Models.Requests.RequestTypes.Tag
{
    public class TaggedPostsRequest : Request
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.ApiKey;

        public override string ApiPath => "/v2/tagged";

        [UriParamName("tag")]
        public string Tag { get; set; }
        
        [UriParamName("before")]
        public DateTimeOffset? Before { get; set; }
        
        [UriParamName("limit")]
        public int? Limit { get; set; }
        
        [UriParamName("filter")]
        [UriParamConverter(typeof(UriAttributeEnumConverter<PostFormat>))]
        public PostFormat? Format { get; set; }

        public TaggedPostsRequest(string tag, DateTimeOffset? before = null, int? limit = null, PostFormat? format = null)
        {
            Tag = tag;
            Before = before;
            Limit = limit;
            Format = format;
        }
    }
}