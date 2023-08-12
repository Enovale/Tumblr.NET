namespace TumblrNET.Models.Requests.RequestTypes.Blog
{
    public class BlogAvatarRequest : BlogRequest
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.None;
        
        protected override string BlogApiPath => $"/avatar{(Size != null ? '/' + Size : "")}";
        
        public int? Size { get; set; }
        
        public BlogAvatarRequest(string blogIdentifier, int? size = null) : base(blogIdentifier)
        {
            Size = size;
        }
    }
}