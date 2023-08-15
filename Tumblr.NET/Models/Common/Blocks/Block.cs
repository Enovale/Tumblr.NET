using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Blocks.Paywall;

namespace TumblrNET.Models.Common.Blocks
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type", UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    [JsonDerivedType(typeof(TextBlock), "text")]
    [JsonDerivedType(typeof(ImageBlock), "image")]
    [JsonDerivedType(typeof(VideoBlock), "video")]
    [JsonDerivedType(typeof(AudioBlock), "audio")]
    [JsonDerivedType(typeof(LinkBlock), "link")]
    [JsonDerivedType(typeof(PaywallBlock), "paywall")]
    [JsonDerivedType(typeof(PollBlock), "poll")]
    public abstract class Block
    {
    }
}