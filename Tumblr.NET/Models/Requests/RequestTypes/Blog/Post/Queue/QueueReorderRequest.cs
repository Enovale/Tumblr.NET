using System.Text.Json.Serialization;
using TumblrNET.Attributes;

namespace TumblrNET.Models.Requests.RequestTypes.Blog.Post.Queue;

public class QueueReorderRequest : QueueRequest
{
    [JsonIgnore]
    public override string QueueApiPath => "/reorder";
    
    [JsonPropertyName("post_id")]
    public string PostId { get; set; }
    
    [JsonPropertyName("insert_after")]
    public string? Index { get; set; }
    
    public QueueReorderRequest(string blogIdentifier, long postId, long? index = null)
        : this(blogIdentifier, postId.ToString(), index?.ToString())
    {
    }
    
    public QueueReorderRequest(string blogIdentifier, string postId, string? index = null) : base(blogIdentifier)
    {
        PostId = postId;
        Index = index;
    }
}