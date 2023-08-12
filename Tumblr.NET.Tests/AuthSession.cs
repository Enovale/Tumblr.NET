using System.Text;
using System.Web;
using NetCoreServer;

namespace TumblrNET.Tests
{
    public class AuthSession : HttpSession
    {
        public AuthSession(HttpServer server) : base(server)
        {
        }

        protected override void OnReceivedRequest(HttpRequest request)
        {
            var query = HttpUtility.ParseQueryString(request.Url.Substring(2));
            Program.SetOAuthed(query.Get("code"), query.Get("state"));
            base.OnReceivedRequest(request);
        }
    }
}