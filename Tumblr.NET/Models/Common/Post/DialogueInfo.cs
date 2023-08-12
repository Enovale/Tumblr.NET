using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Post
{
    public class DialogueInfo
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        
        [JsonPropertyName("label")]
        public required string Label { get; set; }
        
        [JsonPropertyName("phrase")]
        public required string Phrase { get; set; }
    }
}