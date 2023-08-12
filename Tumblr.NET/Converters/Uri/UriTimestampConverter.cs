namespace TumblrNET.Converters.Uri
{
    internal class UriTimestampConverter : UriParamConverter<DateTimeOffset>
    {
        protected override string Serialize(DateTimeOffset value)
        {
            return value.ToUnixTimeMilliseconds().ToString();
        }
    }
}