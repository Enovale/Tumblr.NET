using System.Net;
using System.Web;
using TumblrNET.Converters.Uri;
using TumblrNET.Extensions;
using TumblrNET.Models.Authentication;
using TumblrNET.Models.Common.Blog;
using TumblrNET.Models.Common.Post;
using TumblrNET.Models.Requests;
using TumblrNET.Models.Requests.RequestTypes.Blog;
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

        // TODO So the documentation says that if you are OAuthed this will provide a url
        // but if you are not it will give you the image directly.
        // This is literally just fake and it seems it gives you the url regardless.
        // Need to test this tho with OAuth setup but it isn't currently set up so for now we die.
        public async Task<Uri> GetBlogAvatarUrlAsync(string blogIdentifier)
        {
            var request = new BlogAvatarRequest(blogIdentifier);
            var result = await _core.GetBlogAvatarAsync(_tumblrConfiguration, request);
            // TODO Can I actually force this?
            return result.Headers.Location!;
        }

        public Uri GetBlogAvatarUrl(string blogIdentifier)
        {
            var request = new BlogAvatarRequest(blogIdentifier);
            var result = _core.GetBlogAvatar(_tumblrConfiguration, request);
            // TODO Can I actually force this?
            return result.Headers.Location!;
        }

        /// <summary>
        /// Gets the image data of a blog's avatar as a stream.
        /// </summary>
        /// <param name="blogIdentifier">The blog's blog identifier.</param>
        /// <returns>The image data of the avatar in PNG format.</returns>
        public async Task<Stream> GetBlogAvatarStreamAsync(string blogIdentifier)
        {
            var request = new BlogAvatarRequest(blogIdentifier);
            var result = await _core.GetBlogAvatarAsync(_tumblrConfiguration, request);
            var resultStr = result.Content.ReadAsStringAsync();
            return await result.Content.ReadAsStreamAsync();
        }

        /// <summary>
        /// Gets the image data of a blog's avatar as a stream.
        /// </summary>
        /// <param name="blogIdentifier">The blog's blog identifier.</param>
        /// <returns>The image data of the avatar in PNG format.</returns>
        public Stream GetBlogAvatarStream(string blogIdentifier)
        {
            var request = new BlogAvatarRequest(blogIdentifier);
            var result = _core.GetBlogAvatar(_tumblrConfiguration, request);
            return result.Content.ReadAsStream();
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