using System.Text.Json.Serialization;
using TumblrNET.Models.Common.BlogTypes;

namespace TumblrNET.Models.Responses.ResponseTypes.BlogResponses
{
    public class BlogInfoResponse : Response
    {
        [JsonPropertyName("blog")]
        public required Blog Blog { get; set; }

        internal override void SetClient(Tumblr client)
        {
            Blog.SetClient(client);
        }
    }
}