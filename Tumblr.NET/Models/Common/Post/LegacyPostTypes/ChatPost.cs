using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.PostTypes.LegacyPostTypes
{
    public class ChatPost : TitledPost
    {
        [JsonPropertyName("body")]
        public required string Body { get; set; }
        
        [JsonPropertyName("dialogue")]
        public required DialogueInfo[] Dialogue { get; set; }
    }
}