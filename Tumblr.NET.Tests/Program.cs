using TumblrNET;
using TumblrNET.Models.Authentication;

internal class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        await TestClient();
    }

    private static async Task TestClient()
    {
        var client = new Tumblr(await File.ReadAllTextAsync("apikey"));
        var uri = client.GetAuthorizationRequestUri(new [] { OAuthScope.Basic }, out var state);
        var posts = client.GetBlogPosts("enovale", out var blogInfo);
        var asyncPostsResponse = await client.GetBlogPostsAsync("enovale");
        await using var fileStream = File.OpenWrite("test.png");
        var avatarStream = await client.GetBlogAvatarStreamAsync("enovale");
        await avatarStream.CopyToAsync(fileStream);
    }
}