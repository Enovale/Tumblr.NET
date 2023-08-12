using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using TumblrNET.Attributes;

namespace TumblrNET.Converters.Json
{
    public class JsonAttributeEnumConverter<TEnum> : JsonConverter<TEnum> where TEnum: struct, Enum
    {
        private readonly bool _defaultOnError;

        public JsonAttributeEnumConverter() : this(true)
        {
        }

        public JsonAttributeEnumConverter(bool defaultOnError)
        {
            _defaultOnError = defaultOnError;
        }

        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var name = reader.GetString();

            foreach (var fieldInfo in typeof(TEnum).GetFields())
            {
                var attr = fieldInfo.GetCustomAttribute<EnumValueNameAttribute>(false);

                if (attr != null && attr.Value == name)
                {
                    return (TEnum)fieldInfo.GetValue(null)!;
                }
            }

            return default;
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            var valueStr = value.ToString();
            var type = typeof(TEnum);
            var attr = type.GetField(valueStr)!.GetCustomAttribute<EnumValueNameAttribute>();

            if (attr == null && !_defaultOnError)
            {
                throw new InvalidOperationException(
                    $"The enum value '{type.Name}.{valueStr}' does not have a {nameof(EnumValueNameAttribute)} decorating it.");
            }
            
            writer.WriteStringValue(attr?.Value ?? default(TEnum).ToString());
        }
    }
}