using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Blocks.Paywall
{
    public abstract class TitlePaywallBlock : TextPaywallBlock
    {
        [JsonPropertyName("title")]
        public required string Title { get; set; }
    }
}