using System.Net;
using System.Web;
using TumblrNET.Converters.Uri;
using TumblrNET.Extensions;
using TumblrNET.Models.Authentication;
using TumblrNET.Models.Common.Blog;
using TumblrNET.Models.Common.Post;
using TumblrNET.Models.Requests;
using TumblrNET.Models.Requests.RequestTypes.Blog;
using TumblrNET.Models.Requests.RequestTypes.Tag;
using TumblrNET.Models.Requests.RequestTypes.User;
using TumblrNET.Models.Responses;
using TumblrNET.Models.Responses.ResponseTypes;
using TumblrNET.Models.Responses.ResponseTypes.User;

namespace TumblrNET
{
    public class Tumblr
    {
        public AuthenticationRequirement MaximumAvailableAuthentication => _core.MaximumAvailableAuthentication;

        private readonly TumblrConfiguration _tumblrConfiguration;

        private readonly TumblrCore _core;

        public Tumblr(TumblrConfiguration? config = null)
        {
            _core = new(config);
            _tumblrConfiguration = config ?? new();
        }

        public Tumblr(string consumerKey, TumblrConfiguration? config = null) : this(config)
        {
            _core.ConsumerKey = consumerKey;
        }

        public Tumblr(string consumerKey, string consumerSecret, TumblrConfiguration? config = null)
            : this(consumerKey, config)
        {
            _core.ConsumerSecret = consumerSecret;
        }

        public void SetOAuthToken(string accessToken, string? refreshToken = null, DateTimeOffset? expireyDate = null)
        {
            _core.OAuthState = new OAuth2State
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpirationDate = expireyDate,
                TokenType = "Bearer"
            };
        }

        public async Task RequestAndSetOAuthTokenAsync(string code, string? redirectUrl = null)
        {
            var tokenState = await _core.RequestOAuthAccessCodeAsync(_tumblrConfiguration, code, redirectUrl);
            SetOAuthToken(tokenState.AccessToken, tokenState.RefreshToken);
        }

        public Uri GetAuthorizationRequestUri(OAuthScope[] scopes, out string state, string? redirectUrl = null)
        {
            if (scopes.Length <= 0)
                throw new ArgumentOutOfRangeException(nameof(scopes), "At least one scope must be provided.");
            
            var query = HttpUtility.ParseQueryString(string.Empty);
            query.Add("client_id", _core.ConsumerKey);
            query.Add("response_type", "code");
            query.Add("scope", string.Join(' ', scopes.Select(s => UriParamSerializer.GetConvertedValue(s, new UriAttributeEnumConverter<OAuthScope>()))));
            state = Guid.NewGuid().ToString();
            query.Add("state", state);
            query.Add("redirect_url", redirectUrl);
            
            var builder = new UriBuilder(_tumblrConfiguration.OAuthRoot + "/oauth2/authorize" + "?" + query);
            return builder.Uri;
        }

        public UserInfo GetUserInfo()
        {
            var request = new UserInfoRequest();
            var result = _core.GetUserInfo(_tumblrConfiguration, request);
            ThrowErrorsIfNeeded(result);
            WrapResources(result);
            return result.Response.User;
        }

        public async Task<BlogInfo> GetBlogInfoAsync(string blogIdentifier)
        {
            var request = new BlogInfoRequest(blogIdentifier);
            var result = await _core.GetBlogInfoAsync(_tumblrConfiguration, request);
            ThrowErrorsIfNeeded(result);
            WrapResources(result);
            return result.Response.Blog;
        }

        public BlogInfo GetBlogInfo(string blogIdentifier)
        {
            var request = new BlogInfoRequest(blogIdentifier);
            var result = _core.GetBlogInfo(_tumblrConfiguration, request);
            ThrowErrorsIfNeeded(result);
            WrapResources(result);
            return result.Response.Blog;
        }

        // This works exactly the same as every other request despite what the documentation says.
        // The behavior does not change regardless of authentication, it's always a standard response.
        public async Task<string> GetBlogAvatarUrlAsync(string blogIdentifier)
        {
            var request = new BlogAvatarRequest(blogIdentifier);
            var result = await _core.GetBlogAvatarAsync(_tumblrConfiguration, request);
            ThrowErrorsIfNeeded(result);
            WrapResources(result);
            return result.Response.AvatarUrl;
        }

        public string GetBlogAvatarUrl(string blogIdentifier)
        {
            var request = new BlogAvatarRequest(blogIdentifier);
            var result = _core.GetBlogAvatar(_tumblrConfiguration, request);
            ThrowErrorsIfNeeded(result);
            WrapResources(result);
            return result.Response.AvatarUrl;
        }

        public async Task<(PostInfo[] Posts, BlogInfo Blog)> GetBlogPostsAsync(string blogIdentifier,
            PostType? type = null,
            long? id = null,
            int? limit = null,
            int? offset = null,
            bool? reblogInfo = null,
            bool? notesInfo = null,
            PostFormat? format = null,
            DateTimeOffset? before = null,
            params string[] tags)
        {
            var request = new BlogPostsRequest(blogIdentifier, type, id, limit, offset, reblogInfo, notesInfo, format, before, tags);
            var result = await _core.GetBlogPostsAsync(_tumblrConfiguration, request);
            ThrowErrorsIfNeeded(result);
            WrapResources(result);
            return (result.Response.Posts, result.Response.Blog);
        }

        public PostInfo[] GetBlogPosts(string blogIdentifier, out BlogInfo blogInfo,
            PostType? type = null,
            long? id = null,
            int? limit = null,
            int? offset = null,
            bool? reblogInfo = null,
            bool? notesInfo = null,
            PostFormat? format = null,
            DateTimeOffset? before = null,
            params string[] tags)
        {
            var request = new BlogPostsRequest(blogIdentifier, type, id, limit, offset, reblogInfo, notesInfo, format, before, tags);
            var result = _core.GetBlogPosts(_tumblrConfiguration, request);
            ThrowErrorsIfNeeded(result);
            WrapResources(result);
            blogInfo = result.Response.Blog;
            return result.Response.Posts;
        }
        
        public async Task<List<PostInfo>> GetPostsWithTagAsync(string tag, DateTimeOffset? before = null, int? limit = null, PostFormat? format = null)
        {
            var request = new TaggedPostsRequest(tag, before, limit, format);
            var result = await _core.GetPostsWithTagAsync(_tumblrConfiguration, request);
            ThrowErrorsIfNeeded(result);
            WrapResources(result);
            return result.Response.ToList();
        }

        public List<PostInfo> GetPostsWithTag(string tag, DateTimeOffset? before = null, int? limit = null, PostFormat? format = null)
        {
            var request = new TaggedPostsRequest(tag, before, limit, format);
            var result = _core.GetPostsWithTag(_tumblrConfiguration, request);
            ThrowErrorsIfNeeded(result);
            WrapResources(result);
            return result.Response.ToList();
        }

        private void WrapResources<TResponse>(ResponseWrapper<TResponse> response) where TResponse : Response
        {
            response.Response.SetClient(this);
        }

        private void ThrowErrorsIfNeeded<TResponse>(ResponseWrapper<TResponse> response) where TResponse : Response
        {
            switch (response.Meta.Status)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Found:
                    return;
                default:
                    throw new HttpRequestException($"Tumblr responded with {response.Meta.Status}: {response.Meta.Message}.");
            }
        }
    }
}