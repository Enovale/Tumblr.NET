using System.Text.Json;
using System.Text.Json.Serialization;

namespace TumblrNET.Converters.Json
{
    public class JsonTimeToLiveConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var num = reader.GetUInt64();
        
            return DateTimeOffset.Now.AddSeconds(num);
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            // TODO Probably incorrect im just guessing here cause I don't need it
            writer.WriteNumberValue(value.Subtract(DateTimeOffset.Now).Seconds);
        }
    }
}