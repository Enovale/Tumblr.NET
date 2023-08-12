using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Blocks.Paywall
{
    public class SubscriptionInfo
    {
        [JsonPropertyName("description")]
        public required string Description { get; set; }
        
        [JsonPropertyName("currency_code")]
        public required string CurrencyCode { get; set; }
        
        [JsonPropertyName("monthly_price")]
        public required string MonthlyPrice { get; set; }
        
        [JsonPropertyName("yearly_price")]
        public required string YearlyPrice { get; set; }
        
        [JsonPropertyName("member_perks")]
        public required string[] MemberPerks { get; set; }
        
        [JsonPropertyName("subscription_label")]
        public required string SubscriptionLabel { get; set; }
        
        [JsonPropertyName("checkout_labels")]
        public required CheckoutLabels CheckoutLabels { get; set; }
        
        [JsonPropertyName("is_valid")]
        public required bool IsValid { get; set; }
    }
}