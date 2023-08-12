using System.Text.Json;
using System.Text.Json.Serialization;

namespace TumblrNET.Converters.Json
{
    public class JsonSingleOrArrayConverter<T> : JsonConverter<List<T>>
    {
        public override List<T> Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Null:
                    return null!;
                case JsonTokenType.StartArray:
                    var list = new List<T>();
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.EndArray)
                            break;
                        list.Add(JsonSerializer.Deserialize<T>(ref reader, options)!);
                    }
                    return list;
                default:
                    return new List<T> { JsonSerializer.Deserialize<T>(ref reader, options)! };
            }
        }

        public override void Write(
            Utf8JsonWriter writer,
            List<T> objectToWrite,
            JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, objectToWrite, objectToWrite.GetType(), options);
    }
}