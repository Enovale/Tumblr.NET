using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.PostTypes.LegacyPostTypes
{
    public class AudioPost : CaptionedPost
    {
        [JsonPropertyName("player")]
        public required string PlayerHtml { get; set; }
        
        [JsonPropertyName("plays")]
        public required int Plays { get; set; }
        
        [JsonPropertyName("album_art")]
        public required string AlbumArt { get; set; }
        
        [JsonPropertyName("artist")]
        public required string Artist { get; set; }
        
        [JsonPropertyName("album")]
        public required string Album { get; set; }
        
        [JsonPropertyName("track_name")]
        public required string TrackName { get; set; }
        
        [JsonPropertyName("track_number")]
        public required int TrackNumber { get; set; }
        
        [JsonPropertyName("year")]
        public required int Year { get; set; }
    }
}