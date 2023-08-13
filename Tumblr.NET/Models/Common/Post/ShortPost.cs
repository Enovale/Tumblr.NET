using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Post
{
    public class ShortPost : TumblrResource
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }

        public PostInfo RetrieveFullPost()
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}