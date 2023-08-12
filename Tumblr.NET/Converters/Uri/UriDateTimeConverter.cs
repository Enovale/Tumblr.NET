namespace TumblrNET.Converters.Uri
{
    internal class UriDateTimeConverter : UriParamConverter<DateTime>
    {
        protected override string Serialize(DateTime value)
        {
            return value.ToString("yyyy-mm-dd HH:mm:ss Z");
        }
    }
}