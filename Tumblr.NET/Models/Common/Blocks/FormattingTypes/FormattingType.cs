using TumblrNET.Attributes;

namespace TumblrNET.Models.Common.Blocks.FormattingTypes
{
    public enum FormattingType
    {
        [EnumValueName("bold")]
        Bold,
        
        [EnumValueName("italic")]
        Italic,
        
        [EnumValueName("strikethrough")]
        Strikethrough,
        
        [EnumValueName("small")]
        Small
    }
}