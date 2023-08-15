using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.PostTypes.Notes
{
    public class ReblogNote : Note
    {
        [JsonPropertyName("post_id")]
        public required long PostId { get; set; }
        
        [JsonPropertyName("reblog_parent_blog_name")]
        public required string ParentBlogName { get; set; }
    }
}