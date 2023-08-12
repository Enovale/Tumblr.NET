using TumblrNET.Attributes;

namespace TumblrNET.Models.Common.Blocks.Paywall
{
    public enum PaywallAccessType
    {
        [EnumValueName("member")]
        Member,
        
        [EnumValueName("non-member")]
        NonMember,
        
        [EnumValueName("creator")]
        Creator,
        
        [EnumValueName("disabled")]
        Disabled
    }
}