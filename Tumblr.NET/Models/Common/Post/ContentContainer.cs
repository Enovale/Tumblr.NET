using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Blocks;
using TumblrNET.Models.Common.Blocks.LayoutTypes;

namespace TumblrNET.Models.Common.Post
{
    public class ContentContainer : TumblrResource
    {
        [JsonPropertyName("content")]
        public required Block[] Content { get; set; }
        
        [JsonPropertyName("layout")]
        public required Layout[] Layout { get; set; }
    }
}