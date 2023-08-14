using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.PostTypes.LegacyPostTypes;

public class TitledPost : Post
{
    [JsonPropertyName("title")]
    public required string Title { get; set; }
}