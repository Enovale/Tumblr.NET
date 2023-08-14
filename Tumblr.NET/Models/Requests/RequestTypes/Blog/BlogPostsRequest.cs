using TumblrNET.Attributes;
using TumblrNET.Converters.Uri;
using TumblrNET.Models.Common.PostTypes;

namespace TumblrNET.Models.Requests.RequestTypes.Blog
{
    public class BlogPostsRequest : BlogPaginatedRequest
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.ApiKey;
        
        protected override string BlogApiPath => "/posts";
        
        [UriParamName("type")]
        [UriParamConverter(typeof(UriAttributeEnumConverter<PostType>))]
        public PostType? PostType { get; set; }
        
        [UriParamName("id")]
        public long? PostId { get; set; }
        
        [UriParamName("tag")]
        public string[]? Tags { get; set; }
        
        [UriParamName("reblog_info")]
        public bool? ReblogInfo { get; set; }
        
        [UriParamName("notes_info")]
        public bool? NotesInfo { get; set; }
        
        [UriParamName("filter")]
        [UriParamConverter(typeof(UriAttributeEnumConverter<PostFormat>))]
        public PostFormat? PostFormat { get; set; }
        
        [UriParamName("before")]
        [UriParamConverter(typeof(UriTimestampConverter))]
        public DateTimeOffset? Before { get; set; }

        public BlogPostsRequest(string blogIdentifier,
            PostType? type = null,
            long? id = null,
            int? limit = null,
            int? offset = null,
            bool? reblogInfo = null,
            bool? notesInfo = null,
            PostFormat? format = null,
            DateTimeOffset? before = null,
            params string[] tags) : base(blogIdentifier, limit, offset)
        {
            PostType = type;
            PostId = id;
            ReblogInfo = reblogInfo;
            NotesInfo = notesInfo;
            PostFormat = format;
            Before = before;
            Tags = tags;
        }
    }
}