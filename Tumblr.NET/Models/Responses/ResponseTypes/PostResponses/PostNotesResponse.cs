using System.Text.Json.Serialization;
using TumblrNET.Models.Common.PostTypes.Notes;

namespace TumblrNET.Models.Responses.ResponseTypes.PostResponses
{
    public class PostNotesResponse : Response
    {
        [JsonPropertyName("notes")]
        public required Note[] Notes { get; set; }
        
        [JsonPropertyName("total_notes")]
        public int TotalNotes { get; set; }

        internal override void SetClient(Tumblr client)
        {
            foreach (var note in Notes)
            {
                note.SetClient(client);
            }
        }
    }
}