namespace TumblrNET.Converters.Uri
{
    // This class is unsafe and expects well checked input.
    internal abstract class UriParamConverter<TSource> : UriParamConverter
    {
        public override bool CanSerialize(object? value)
            => value is TSource;

        public override string Serialize(object? value)
            => Serialize((TSource)value!);

        protected abstract string Serialize(TSource value);
    }

    internal abstract class UriParamConverter
    {
        public abstract bool CanSerialize(object? value);
        
        public abstract string Serialize(object? value);
    }
}