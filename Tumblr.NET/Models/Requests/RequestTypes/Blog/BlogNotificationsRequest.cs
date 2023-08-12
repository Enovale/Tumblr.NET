using TumblrNET.Attributes;
using TumblrNET.Converters.Uri;
using TumblrNET.Models.Common.ActivityTypes;

namespace TumblrNET.Models.Requests.RequestTypes.Blog
{
    public class BlogNotificationsRequest : BlogRequest
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.OAuth;

        protected override string BlogApiPath => "/notifications";
        
        [UriParamName("before")]
        [UriParamConverter(typeof(UriTimestampConverter))]
        public DateTimeOffset? Before { get; set; }
        
        // TODO This probably doesn't work at all but I don't care to check
        [UriParamName("types")]
        [UriParamConverter(typeof(UriAttributeEnumConverter<ActivityType>))]
        public ActivityType[]? Types { get; set; }
        
        [UriParamName("rollups")]
        public bool? Rollup { get; set; }
        
        [UriParamName("omit_post_ids")]
        public long[]? OmitPostIds { get; set; }
        
        public BlogNotificationsRequest(string blogIdentifier, DateTimeOffset? before = null, bool? rollup = null, long[]? omitPostIds = null, params ActivityType[] types) : base(blogIdentifier)
        {
            Before = before;
            Types = types.Length > 0 ? types : null;
            Rollup = rollup;
            OmitPostIds = omitPostIds;
        }
    }
}