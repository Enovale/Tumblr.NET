using System.Text.Json.Serialization;

namespace TumblrNET.Models.Common.Blocks.LayoutTypes
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(RowsLayout), "rows")]
    [JsonDerivedType(typeof(CondensedLayout), "condensed")]
    [JsonDerivedType(typeof(AskLayout), "ask")]
    public abstract class Layout
    {
    }
}