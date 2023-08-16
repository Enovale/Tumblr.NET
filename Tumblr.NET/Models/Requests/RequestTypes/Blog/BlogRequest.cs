using System.Text.Json.Serialization;

namespace TumblrNET.Models.Requests.RequestTypes.Blog
{
    public abstract class BlogRequest : Request
    {
        [JsonIgnore]
        public abstract override AuthenticationRequirement Auth { get; }

        [JsonIgnore]
        protected abstract string BlogApiPath { get; }

        [JsonIgnore]
        public sealed override string ApiPath => $"/v2/blog/{BlogIdentifier}{BlogApiPath}";

        [JsonIgnore]
        public string BlogIdentifier { get; set; }

        public BlogRequest(string blogIdentifier)
        {
            BlogIdentifier = blogIdentifier;
        }
    }
}