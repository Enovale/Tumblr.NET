using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TumblrNET.Converters.Json
{
    public class JsonColorConverter : JsonConverter<Color>
    {
        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();

            if (str == null)
            {
                throw new NullReferenceException("String to write is null.");
            }

            // Tumblr's image blocks don't have the # at the start for literally no reason.
            if (!str.StartsWith('#'))
                str = "#" + str;
            
            return ColorTranslator.FromHtml(str);
        }

        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options) =>
            writer.WriteStringValue("#" + value.R.ToString("X2") + value.G.ToString("X2") +
                                    value.B.ToString("X2").ToLower());
    }
}