using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.PostTypes.LegacyPostTypes
{
    public class AnswerPost : Post
    {
        [JsonPropertyName("asking_name")]
        public required string AskingName { get; set; }
        
        [JsonPropertyName("asking_url")]
        public required string AskingUrl { get; set; }
        
        [JsonPropertyName("question")]
        public required string Question { get; set; }
        
        [JsonPropertyName("answer")]
        public required string Answer { get; set; }
    }
}