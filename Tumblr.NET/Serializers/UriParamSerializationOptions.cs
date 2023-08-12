using TumblrNET.Converters.Uri;

namespace TumblrNET.Extensions
{
    internal class UriParamSerializationOptions
    {
        public List<UriParamConverter> Converters { get; set; } = new();
    }
}