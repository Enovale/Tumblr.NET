using TumblrNET.Attributes;

namespace TumblrNET.Models.Authentication
{
    public enum OAuthScope
    {
        [EnumValueName("basic")]
        Basic,
        
        [EnumValueName("write")]
        Write,
        
        [EnumValueName("offline_access")]
        OfflineAccess
    }
}