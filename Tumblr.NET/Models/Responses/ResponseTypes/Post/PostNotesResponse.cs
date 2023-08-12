using System.Text.Json.Serialization;
using TumblrNET.Models.Common.Post.Notes;

namespace TumblrNET.Models.Responses.ResponseTypes.Post
{
    public class PostNotesResponse : Response
    {
        [JsonPropertyName("notes")]
        public required Note[] Notes { get; set; }
        
        [JsonPropertyName("total_notes")]
        public int TotalNotes { get; set; }
    }
}