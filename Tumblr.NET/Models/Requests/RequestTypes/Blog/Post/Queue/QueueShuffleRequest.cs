namespace TumblrNET.Models.Requests.RequestTypes.Blog.Post.Queue
{
    public class QueueShuffleRequest : QueueRequest
    {
        public override string QueueApiPath => "/shuffle";
    
        public QueueShuffleRequest(string blogIdentifier) : base(blogIdentifier)
        {
        }
    }
}