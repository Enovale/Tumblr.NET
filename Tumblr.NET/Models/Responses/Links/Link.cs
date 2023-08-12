using System.Text.Json.Serialization;

namespace TumblrNET.Models.Responses.Links
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(ActionLink), "action")]
    [JsonDerivedType(typeof(NavigationLink), "navigation")]
    public abstract class Link
    {
        [JsonPropertyName("href")]
        public required string Href { get; set; }
    }
}