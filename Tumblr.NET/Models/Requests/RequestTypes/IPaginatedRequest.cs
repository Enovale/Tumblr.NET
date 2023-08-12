namespace TumblrNET.Models.Requests.RequestTypes
{
    public interface IPaginatedRequest
    {
        public int? Limit { get; set; }
        
        public int? Offset { get; set; }
    }
}