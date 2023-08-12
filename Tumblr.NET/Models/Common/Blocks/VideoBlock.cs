using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Media;

namespace TumblrNET.Models.Common.Blocks
{
    public class VideoBlock : AudioVideoBlock
    {
        /// <summary>
        /// Undocumented.
        /// </summary>
        [JsonPropertyName("filmstrip")]
        public MediaDescription? Filmstrip { get; set; }
        
        [JsonPropertyName("embed_iframe")]
        public Iframe? EmbedIframe { get; set; }
        
        [JsonPropertyName("can_autoplay_on_cellular")]
        public bool? CanAutoplayOnCellular { get; set; }
    }
}