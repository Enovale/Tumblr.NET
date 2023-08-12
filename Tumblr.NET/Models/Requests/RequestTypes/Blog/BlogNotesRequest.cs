using TumblrNET.Attributes;
using TumblrNET.Converters.Uri;

namespace TumblrNET.Models.Requests.RequestTypes.Blog
{
    public class BlogNotesRequest : BlogRequest
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.ApiKey;

        protected override string BlogApiPath => "/notes";
        
        [UriParamName("id")]
        public long PostId { get; set; }
        
        [UriParamName("before_timestamp")]
        [UriParamConverter(typeof(UriTimestampConverter))]
        public DateTimeOffset? Before { get; set; }
        
        [UriParamName("mode")]
        [UriParamConverter(typeof(UriAttributeEnumConverter<NotesMode>))]
        public NotesMode? Mode { get; set; }
        
        public BlogNotesRequest(string blogIdentifier, long postId, DateTimeOffset? before = null, NotesMode? mode = null) : base(blogIdentifier)
        {
            PostId = postId;
            Before = before;
            Mode = mode;
        }
    }
}