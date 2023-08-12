using TumblrNET.Attributes;

namespace TumblrNET.Models.Common.Post
{
    public enum PostFormat
    {
        [EnumValueName("html")]
        Html,
        
        [EnumValueName("markdown")]
        Markdown,
        
        [EnumValueName("raw")]
        Raw
    }
}