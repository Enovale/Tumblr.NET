namespace TumblrNET.Models.Requests.RequestTypes.User
{
    public abstract class UserRequest : Request
    {
        public override AuthenticationRequirement Auth => AuthenticationRequirement.OAuth;

        public abstract string UserApiPath { get; }
        
        public sealed override string ApiPath => $"/v2/user{UserApiPath}";
    }
}