using TumblrNET.Attributes;

namespace TumblrNET.Models.Requests.RequestTypes.Blog
{
    public enum NotesMode
    {
        [EnumValueName("all")]
        All,
        
        [EnumValueName("likes")]
        Likes,
        
        [EnumValueName("conversation")]
        Conversation,
        
        [EnumValueName("rollup")]
        Rollup,
        
        [EnumValueName("reblogs_with_tags")]
        ReblogsWithTags
    }
}