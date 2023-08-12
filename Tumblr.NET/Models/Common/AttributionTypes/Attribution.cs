using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.AttributionTypes
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(LinkAttribution), "link")]
    [JsonDerivedType(typeof(BlogAttribution), "blog")]
    [JsonDerivedType(typeof(PostAttribution), "post")]
    [JsonDerivedType(typeof(AppAttribution), "app")]
    public class Attribution
    {
    }
}