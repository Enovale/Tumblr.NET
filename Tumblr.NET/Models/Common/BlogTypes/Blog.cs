using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;
using TumblrNET.Models.Common.Media;
using TumblrNET.Models.Common.PostTypes;

namespace TumblrNET.Models.Common.BlogTypes
{
    public class Blog : TumblrResource
    {
        [JsonPropertyName("title")]
        public required string Title { get; set; }
        
        [JsonPropertyName("posts")]
        public required int PostCount { get; set; }
        
        [JsonPropertyName("name")]
        public required string Username { get; set; }
        
        [JsonPropertyName("updated")]
        [JsonConverter(typeof(JsonTimestampConverter))]
        public required DateTimeOffset Updated { get; set; }
        
        [JsonPropertyName("description")]
        public required string Description { get; set; }
        
        [JsonPropertyName("ask")]
        public required bool AllowAsks { get; set; }
        
        [JsonPropertyName("ask_anon")]
        public required bool AllowAnonymousAsks { get; set; }
        
        [JsonPropertyName("followed")]
        public bool? FollowedByPrimary { get; set; }
        
        [JsonPropertyName("likes")]
        public int? Likes { get; set; }
        
        [JsonPropertyName("is_blocked_from_primary")]
        public bool? BlockedFromPrimary { get; set; }
        
        [JsonPropertyName("avatar")]
        public required MediaDescription[] Avatars { get; set; }
        
        [JsonPropertyName("url")]
        public required string Url { get; set; }
        
        [JsonPropertyName("theme")]
        public required BlogTheme Theme { get; set; }
        
        [JsonPropertyName("is_following_you")]
        public bool? FollowingPrimary { get; set; }
        
        [JsonPropertyName("duration_blog_following_you")]
        public long? FollowingPrimaryDuration { get; set; }
        
        [JsonPropertyName("duration_following_blog")]
        public long? FollowedByPrimaryDuration { get; set; }
        
        [JsonPropertyName("timezone")]
        public string? Timezone { get; set; }
        
        [JsonPropertyName("timezone_offset")]
        public string? TimezoneOffset { get; set; }

        public string RetrieveAvatarUrl()
        {
            return Client.GetBlogAvatarUrl(Username);
        }

        public Post[] RetrievePosts(PostType? type = null,
            long? id = null,
            int? limit = null,
            int? offset = null,
            bool? reblogInfo = null,
            bool? notesInfo = null,
            PostFormat? format = null,
            DateTimeOffset? before = null,
            params string[] tags)
        {
            return Client.GetBlogPosts(Username, out _, type, id, limit, offset, reblogInfo, notesInfo, format, before, tags);
        }
    }
}