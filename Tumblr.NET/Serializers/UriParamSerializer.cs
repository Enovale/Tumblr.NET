using System.Collections;
using System.Collections.Specialized;
using TumblrNET.Converters.Uri;

namespace TumblrNET.Extensions
{
    internal static class NameValueCollectionExtensions
    {
        public static void AddWithConverters(this NameValueCollection obj, string? name, object? value, UriParamSerializationOptions? options = null)
        {
            if (options is { Converters.Count: > 0 })
            {
                foreach (var converter in options.Converters)
                {
                    if (converter.CanSerialize(value))
                    {
                        obj.AddWithConverter(name, value, converter);
                        return;
                    }
                }
            }
            
            obj.AddWithConverter(name, value);
        }

        public static void AddWithConverter(this NameValueCollection obj, string? name, object? value, UriParamConverter? converter = null)
        {
            if (value is string str)
            {
                obj.Add(name, str);
                return;
            }

            if (value is Array arr)
            {
                for (var i = 0; i < arr.Length; i++)
                {
                    obj.AddWithConverter($"{name}[{i}]", arr.GetValue(i), converter);
                }

                return;
            }

            if (value is IDictionary dict)
            {
                foreach (DictionaryEntry entry in dict)
                {
                    obj.AddWithConverter($"{name}[{GetConvertedValue(entry.Key, converter)}]", entry.Value, converter);
                }
            }
            
            if (converter == null)
            {
                obj.Add(name, value?.ToString());
                return;
            }
            
            obj.Add(name, GetConvertedValue(value, converter));
        }

        public static string? GetConvertedValue(object? value, UriParamConverter? converter)
            => Convert(value, converter) ?? value?.ToString();

        private static string? Convert(object? value, UriParamConverter? converter)
            => converter?.Serialize(value);
    }
}