using TumblrNET.Attributes;

namespace TumblrNET.Models.Common.PostTypes
{
    public enum PostState
    {
        [EnumValueName("published")]
        Published,
        
        [EnumValueName("queued")]
        Queued,
        
        [EnumValueName("draft")]
        Draft,
        
        [EnumValueName("private")]
        Private
    }
}