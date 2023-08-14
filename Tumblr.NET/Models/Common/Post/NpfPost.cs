using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Blocks;
using TumblrNET.Models.Common.Blocks.LayoutTypes;

namespace TumblrNET.Models.Common.PostTypes
{
    public class NpfPost : Post
    {
        [JsonPropertyName("content")]
        public Block[]? Content { get; set; }
        
        [JsonPropertyName("layout")]
        public Layout[]? Layout { get; set; }
        
        [JsonPropertyName("trail")]
        public TrailItem[]? Trail { get; set; }

        internal override void SetClient(Tumblr client)
        {
            base.SetClient(client);
        
            if (Trail != null)
            {
                foreach (var trailItem in Trail)
                {
                    trailItem.SetClient(client);
                }
            }
        }
    }
}