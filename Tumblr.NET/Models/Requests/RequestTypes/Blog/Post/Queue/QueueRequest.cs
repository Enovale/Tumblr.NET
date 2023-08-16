using System.Text.Json.Serialization;

namespace TumblrNET.Models.Requests.RequestTypes.Blog.Post.Queue
{
    public abstract class QueueRequest : PostRequest
    {
        [JsonIgnore]
        public sealed override AuthenticationRequirement Auth => AuthenticationRequirement.OAuth;

        [JsonIgnore]
        public abstract string QueueApiPath { get; }
    
        [JsonIgnore]
        protected sealed override string PostApiPath => $"/queue{QueueApiPath}";
    
        public QueueRequest(string blogIdentifier) : base(blogIdentifier)
        {
        }
    }
}