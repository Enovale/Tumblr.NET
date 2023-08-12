using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Blog;

namespace TumblrNET.Models.Common.Post
{
    /*
     * TODO This API is fucking garbage and during Trails it's basically completely
     * undefined what is and isn't included in the trail's post and blog properties
     * so for now we're just making the end user figure it out.
     */
    public class TrailItem : ContentContainer
    {
        [JsonPropertyName("post")]
        public ShortPost? Post { get; set; }
        
        [JsonPropertyName("blog")]
        public ShortBlog? Blog { get; set; }
        
        [JsonPropertyName("broken_blog_name")]
        public string? BrokenBlogName { get; set; }
    }
}