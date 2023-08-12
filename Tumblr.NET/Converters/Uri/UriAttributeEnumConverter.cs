using System.Reflection;
using TumblrNET.Attributes;

namespace TumblrNET.Converters.Uri
{
    internal class UriAttributeEnumConverter<TEnum> : UriParamConverter<TEnum> where TEnum: struct, Enum
    {
        private readonly bool _defaultOnError;

        public UriAttributeEnumConverter() : this(true)
        {
        }

        public UriAttributeEnumConverter(bool defaultOnError)
        {
            _defaultOnError = defaultOnError;
        }

        protected override string Serialize(TEnum value)
        {
            var valueStr = value.ToString();
            var type = typeof(TEnum);
            var attr = type.GetField(valueStr)!.GetCustomAttribute<EnumValueNameAttribute>();

            if (attr == null && !_defaultOnError)
            {
                throw new InvalidOperationException(
                    $"The enum value '{type.Name}.{valueStr}' does not have a {nameof(EnumValueNameAttribute)} decorating it.");
            }
            
            return attr?.Value ?? default(TEnum).ToString();
        }
    }
}