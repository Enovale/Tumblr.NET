using TumblrNET.Attributes;

namespace TumblrNET.Models.Common.Post
{
    public enum PostType
    {
        [EnumValueName("blocks")]
        Blocks,
        
        [EnumValueName("text")]
        Text,
        
        [EnumValueName("quote")]
        Quote,
        
        [EnumValueName("link")]
        Link,
        
        [EnumValueName("answer")]
        Answer,
        
        [EnumValueName("video")]
        Video,
        
        [EnumValueName("audio")]
        Audio,
        
        [EnumValueName("photo")]
        Photo,
        
        [EnumValueName("chat")]
        Chat
    }
}