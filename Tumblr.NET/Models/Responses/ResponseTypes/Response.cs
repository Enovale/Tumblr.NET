using System.Text.Json.Serialization;
using TumblrNET.Models.Responses.Links;
using TumblrNET.Models.Responses.ResponseTypes.BlogResponses;
using TumblrNET.Models.Responses.ResponseTypes.PostResponses;
using TumblrNET.Models.Responses.ResponseTypes.TagResponses;
using TumblrNET.Models.Responses.ResponseTypes.UserResponses;

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
        public Dictionary<string, Link>? Links { get; set; }

        internal virtual void SetClient(Tumblr client)
        {
        }
    }
}