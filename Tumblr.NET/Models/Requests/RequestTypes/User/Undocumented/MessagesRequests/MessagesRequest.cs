using TumblrNET.Attributes;

namespace TumblrNET.Models.Requests.RequestTypes.User.Undocumented.MessagesRequests
{
    public class MessagesRequest : Request
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.OAuth;
    
        // TODO this is actually on the root domain and not the api path, but the request system doesn't support this...
        public override string ApiPath => "/api/v2/conversations/messages";
    
        [UriParamName("participant")]
        public required string Participant { get; set; }
    
        [UriParamName("conversation_id")]
        public required long ConversationId { get; set; }

        public MessagesRequest(string participant, long conversationId)
        {
            Participant = participant;
            ConversationId = conversationId;
        }
    }
}