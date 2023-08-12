namespace TumblrNET.Attributes
{
    public class UriParamConverterAttribute : Attribute
    {
        public Type ConverterType { get; }
        
        public UriParamConverterAttribute(Type converterType)
        {
            ConverterType = converterType;
        }
    }
}