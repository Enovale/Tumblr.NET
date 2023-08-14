using TumblrNET;
using TumblrNET.Models.Authentication;
using TumblrNET.Models.Responses.ResponseTypes.User;
using TumblrNET.Tests;

internal class Program
{
    private static Tumblr _client;

    private static string _state;

    private static UserInfo _user;

    public static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        await TestClient();
    }

    private static async Task TestClient()
    {
        var server = new AuthServer("0.0.0.0", 8888);
        server.Start();
        _client = new Tumblr(await File.ReadAllTextAsync("apikey"), await File.ReadAllTextAsync("secret"));
        var uri = _client.GetAuthorizationRequestUri(new [] { OAuthScope.Basic }, out _state);
        Console.WriteLine(uri);
        var taggedPosts = await _client.GetPostsWithTagAsync("food");
        var posts = _client.GetBlogPosts("enovale", out var blogInfo);
        var asyncPostsResponse = await _client.GetBlogPostsAsync("enovale");

        for (;;)
        {
            string line = Console.ReadLine();
            if (string.IsNullOrEmpty(line))
                break;

            // Restart the server
            if (line == "!")
            {
                Console.Write("Server restarting...");
                server.Restart();
                Console.WriteLine("Done!");
            }
        } 
        
        server.Stop();
    }

    public static async Task SetOAuthed(string code, string state)
    {
        if (state != _state)
        {
            throw new ArgumentOutOfRangeException("Somehow the state is different what the hell");
        }

        await _client.RequestAndSetOAuthTokenAsync(code);
        _user = _client.GetUserInfo();
        var avatarUrl = await _client.GetBlogAvatarUrlAsync("enovale");
    }
}