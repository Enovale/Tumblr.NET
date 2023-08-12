namespace TumblrNET.Models.Requests.RequestTypes.Blog.Post
{
    public class PostFetchRequest : PostRequest
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.OAuth;
        
        protected override string PostApiPath => $"/{PostId}";
        
        public long PostId { get; set; }
        
        public PostFetchRequest(string blogIdentifier, long postId) : base(blogIdentifier)
        {
            PostId = postId;
        }
    }
}