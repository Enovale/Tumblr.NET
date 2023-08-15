using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TumblrNET.Converters.Json
{
    public class JsonGmtStringConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();

            if (str == null)
                throw new InvalidOperationException("Failed to read string.");

            return DateTime.ParseExact(str, "yyyy-MM-dd HH:mm:ss Z", CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-mm-dd HH:mm:ss Z"));
        }
    }
}