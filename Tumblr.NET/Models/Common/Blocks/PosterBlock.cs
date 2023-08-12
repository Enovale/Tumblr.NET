using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Media;

namespace TumblrNET.Models.Common.Blocks
{
    public abstract class PosterBlock : Block
    {
        [JsonPropertyName("poster")]
        public MediaDescription[]? Poster { get; set; }
    }
}