using System.Text.Json;
using System.Text.Json.Serialization;

namespace TumblrNET.Converters.Json
{
    public class JsonTimestampConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var num = reader.GetUInt64();

            return DateTimeOffset.FromUnixTimeSeconds((long)num);
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options) =>
            writer.WriteNumberValue(value.ToUnixTimeSeconds());
    }
}