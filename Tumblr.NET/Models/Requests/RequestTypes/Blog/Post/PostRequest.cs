using System.Text.Json.Serialization;

namespace TumblrNET.Models.Requests.RequestTypes.Blog.Post
{
    public abstract class PostRequest : BlogRequest
    {
        [JsonIgnore]
        public abstract override AuthenticationRequirement Auth { get; }
        
        [JsonIgnore]
        protected abstract string PostApiPath { get; }

        [JsonIgnore]
        protected sealed override string BlogApiPath => $"/posts{PostApiPath}";
        
        public PostRequest(string blogIdentifier) : base(blogIdentifier)
        {
        }
    }
}