namespace TumblrNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumValueNameAttribute : Attribute
    {
        public string Value { get; set; }
        
        public EnumValueNameAttribute(string value)
        {
            Value = value;
        }
    }
}