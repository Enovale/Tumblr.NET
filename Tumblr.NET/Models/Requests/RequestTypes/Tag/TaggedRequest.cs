using System.Text.Json.Serialization;
using TumblrNET.Attributes;
using TumblrNET.Converters.Json;
using TumblrNET.Models.Common.Post;

namespace TumblrNET.Models.Requests.RequestTypes.Tag
{
    public abstract class TaggedRequest : Request
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.ApiKey;

        public override string ApiPath => "/v2/tagged";

        [UriParamName("tag")]
        public required string Tag { get; set; }
        
        [UriParamName("before")]
        public DateTimeOffset? Before { get; set; }
        
        [UriParamName("limit")]
        public int? Limit { get; set; }
        
        [UriParamName("filter")]
        [JsonConverter(typeof(JsonAttributeEnumConverter<PostFormat>))]
        public PostFormat? Format { get; set; }

        public TaggedRequest(string tag, DateTimeOffset? before = null, int? limit = null, PostFormat? format = null)
        {
            Tag = tag;
            Before = before;
            Limit = limit;
            Format = format;
        }
    }
}