using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Blocks.Paywall
{
    public abstract class TextPaywallBlock : PaywallBlock
    {
        [JsonPropertyName("text")]
        public required string Text { get; set; }
    }
}