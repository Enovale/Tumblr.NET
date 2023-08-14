using System.Text.Json.Serialization;

namespace TumblrNET.Models.Responses.Links
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type", IgnoreUnrecognizedTypeDiscriminators = true,
        UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonDerivedType(typeof(ActionLink), "action")]
    [JsonDerivedType(typeof(NavigationLink), "navigation")]
    public class Link
    {
        [JsonPropertyName("href")]
        public required string Href { get; set; }
    }
}