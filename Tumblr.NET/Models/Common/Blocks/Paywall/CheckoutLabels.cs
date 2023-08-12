using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Blocks.Paywall
{
    public class CheckoutLabels
    {
        [JsonPropertyName("monthly")]
        public required string Monthly { get; set; }
        
        [JsonPropertyName("yearly")]
        public required string Yearly { get; set; }
        
        [JsonPropertyName("support")]
        public required string Support { get; set; }
    }
}