using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Blocks.Paywall
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "subtype")]
    [JsonDerivedType(typeof(CtaPaywallBlock), "cta")]
    [JsonDerivedType(typeof(DisabledPaywallBlock), "disabled")]
    [JsonDerivedType(typeof(DividerPaywallBlock), "divider")]
    public abstract class PaywallBlock : Block
    {
        [JsonPropertyName("url")]
        public required string Url { get; set; }
        
        [JsonPropertyName("is_visible")]
        public bool? IsVisible { get; set; }
    }
}