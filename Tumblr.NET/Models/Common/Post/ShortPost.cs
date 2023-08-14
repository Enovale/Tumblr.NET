using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.PostTypes
{
    public class ShortPost : TumblrResource
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }

        public Post RetrieveFullPost()
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}