using System.Text.Json.Serialization;

namespace TumblrNET.Models.Requests.RequestTypes.User.Undocumented.MessagesRequests
{
    // Undocumented, reverse engineered from the website.
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(PostRefSendMessageRequest), "POSTREF")]
    public class SendMessageRequest : Request
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.OAuth;

        public override string ApiPath => "/api/v2/conversations/messages";
    
        [JsonPropertyName("conversation_id")]
        public required string ConversationId { get; set; }
    
        [JsonPropertyName("message")]
        public required string Message { get; set; }
    
        [JsonPropertyName("participant")]
        public required string PartipantUuid { get; set; }
    }
}