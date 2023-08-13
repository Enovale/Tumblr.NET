using System.Text.Json.Serialization;
using TumblrNET.Models.Responses.Links;
using TumblrNET.Models.Responses.ResponseTypes.Blog;
using TumblrNET.Models.Responses.ResponseTypes.Post;
using TumblrNET.Models.Responses.ResponseTypes.Tag;
using TumblrNET.Models.Responses.ResponseTypes.User;

namespace TumblrNET.Models.Responses.ResponseTypes
{
    [JsonDerivedType(typeof(BlogAvatarResponse))]
    [JsonDerivedType(typeof(BlogBlockResponse))]
    [JsonDerivedType(typeof(BlogDraftsResponse))]
    [JsonDerivedType(typeof(BlogFollowedByResponse))]
    [JsonDerivedType(typeof(BlogFollowerResponse))]
    [JsonDerivedType(typeof(BlogFollowingResponse))]
    [JsonDerivedType(typeof(BlogInfoResponse))]
    [JsonDerivedType(typeof(BlogLikesResponse))]
    [JsonDerivedType(typeof(BlogNotificationsResponse))]
    [JsonDerivedType(typeof(BlogPostsResponse))]
    [JsonDerivedType(typeof(BlogQueuesResponse))]
    [JsonDerivedType(typeof(BlogSubmissionsResponse))]
    [JsonDerivedType(typeof(PostNotesResponse))]
    [JsonDerivedType(typeof(FetchPostResponse))]
    [JsonDerivedType(typeof(TaggedPostsResponse))]
    [JsonDerivedType(typeof(UserDashboardResponse))]
    [JsonDerivedType(typeof(UserFollowingResponse))]
    [JsonDerivedType(typeof(UserInfoResponse))]
    [JsonDerivedType(typeof(UserLikesResponse))]
    [JsonDerivedType(typeof(UserLimitResponse))]
    public abstract class Response
    {
        [JsonPropertyName("_links")]
        // TODO This should be a base Link but APPARENTLY Tumblr fucking lied about the type property
        public Dictionary<string, ActionLink>? Links { get; set; }

        internal virtual void SetClient(Tumblr client)
        {
        }
    }
}