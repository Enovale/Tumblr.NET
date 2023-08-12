using TumblrNET.Attributes;

namespace TumblrNET.Models.Common.Blocks
{
    public enum TextSubtype
    {
        Normal,
        
        [EnumValueName("heading1")]
        Heading1,
        
        [EnumValueName("heading2")]
        Heading2,
        
        [EnumValueName("quirky")]
        Quirky,
        
        [EnumValueName("quote")]
        Quote,
        
        [EnumValueName("indented")]
        Indented,
        
        [EnumValueName("chat")]
        Chat,
        
        [EnumValueName("ordered-list-item")]
        OrderedListItem,
        
        [EnumValueName("unordered-list-item")]
        UnorderedListItem
    }
}