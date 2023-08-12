namespace TumblrNET.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UriParamNameAttribute : Attribute
    {
        public string Name { get; set; }
        
        public UriParamNameAttribute(string name)
        {
            Name = name;
        }
    }
}