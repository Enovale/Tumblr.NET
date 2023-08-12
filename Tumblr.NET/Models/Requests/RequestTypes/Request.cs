using System.Collections.Specialized;
using System.Reflection;
using System.Web;
using TumblrNET.Attributes;
using TumblrNET.Converters.Uri;
using TumblrNET.Extensions;

namespace TumblrNET.Models.Requests.RequestTypes
{
    public abstract class Request
    {
        internal NameValueCollection GetParams(UriParamSerializationOptions? options = null)
        {
            var nvc = HttpUtility.ParseQueryString(string.Empty);

            foreach (var prop in GetType().GetProperties())
            {
                var attr = prop.GetCustomAttribute<UriParamNameAttribute>();

                if (attr != null)
                {
                    var value = prop.GetValue(this);
                    
                    if (value != null)
                    {
                        var attr2 = prop.GetCustomAttribute<UriParamConverterAttribute>();

                        if (attr2 != null)
                        {
                            var converter = Activator.CreateInstance(attr2.ConverterType) as UriParamConverter;

                            if (converter == null)
                            {
                                throw new InvalidOperationException($"Type '{attr2.ConverterType.Name}' could not be instantiated.");
                            }
                            
                            nvc.AddWithConverter(attr.Name, value, converter);
                        }
                        else
                            nvc.AddWithConverters(attr.Name, value, options);
                    }
                }
            }

            return nvc;
        }

        public abstract AuthenticationRequirement Auth { get; }
        
        public abstract string ApiPath { get; }
        
        [UriParamName("fields")]
        public Dictionary<string, string[]>? Fields { get; set; }
    }
}