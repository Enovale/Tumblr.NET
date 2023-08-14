using TumblrNET.Attributes;
using TumblrNET.Models.Common.PostTypes;

namespace TumblrNET.Models.Requests.RequestTypes.User
{
    public class UserDashboardRequest : UserPaginatedRequest
    {
        public override string UserApiPath => "/dashboard";
        
        [UriParamName("type")]
        public PostType? PostType { get; set; }
        
        [UriParamName("since_id")]
        public long? SincePostId { get; set; }
        
        [UriParamName("reblog_info")]
        public bool? ReblogInfo { get; set; }
        
        [UriParamName("notes_info")]
        public bool? NotesInfo { get; set; }
        
        public UserDashboardRequest(int? limit = null, int? offset = null, PostType? postType = null, long? sincePostId = null, bool? reblogInfo = null, bool? notesInfo = null) : base(limit, offset)
        {
            PostType = postType;
            SincePostId = sincePostId;
            ReblogInfo = reblogInfo;
            NotesInfo = NotesInfo;
        }
    }
}