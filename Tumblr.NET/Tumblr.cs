using System.Net;
using System.Web;
using TumblrNET.Models.Common.Blog;
using TumblrNET.Models.Common.Post;
using TumblrNET.Models.Requests;
using TumblrNET.Models.Requests.RequestTypes.Blog;
using TumblrNET.Models.Responses;
using TumblrNET.Models.Responses.ResponseTypes;

namespace TumblrNET
{
    public class Tumblr
    {
        private TumblrConfiguration _tumblrConfiguration { get; set; }
        
        public string? ConsumerKey { get; }
        
        public string? ConsumerSecret { get; }
        
        public AuthenticationRequirement MaximumAvailableAuthentication
        {
            get
            {
                if (ConsumerKey != null && ConsumerSecret != null)
                    return AuthenticationRequirement.OAuth;
                
                if (ConsumerKey != null)
                    return AuthenticationRequirement.ApiKey;

                return AuthenticationRequirement.None;
            }
        }

        private TumblrCore _core;

        public Tumblr(TumblrConfiguration? config = null)
        {
            _core = new(config);
            _tumblrConfiguration = config ?? new();
        }

        public Tumblr(string consumerKey, TumblrConfiguration? config = null) : this(config)
        {
            ConsumerKey = consumerKey;
        }

        public Tumblr(string consumerKey, string consumerSecret, TumblrConfiguration? config = null)
            : this(consumerKey, config)
        {
            ConsumerSecret = consumerSecret;
        }

        public bool TrySetApiKey(string key)
        {
            _tumblrConfiguration.ApiKey = key;
            _tumblrConfiguration.ApiKeyValid = true;

            try
            {
                var test = GetBlogInfo("staff");
                _ = test.Title;
            }
            catch (Exception e)
            {
                _tumblrConfiguration.ApiKeyValid = false;
                return false;
            }

            _tumblrConfiguration.ApiKeyValid = true;
            return true;
        }

        public Uri GetAuthorizationRequestUri(TumblrConfiguration config, out string state)
        {
            // TODO WIP
            var query = HttpUtility.ParseQueryString(string.Empty);
            query.Add("response_type", "code");
            state = new Guid().ToString();
            query.Add("state", state);
            
            var builder = new UriBuilder(config.OAuthRoot + "/oauth2/authorize" + "?" + query);
            return builder.Uri;
        }

        public async Task<BlogInfo> GetBlogInfoAsync(string blogIdentifier)
        {
            var request = new BlogInfoRequest(blogIdentifier);
            var result = await _core.GetBlogInfoAsync(_tumblrConfiguration, request);
            ThrowErrorsIfNeeded(result);
            return result.Response.Blog;
        }

        public BlogInfo GetBlogInfo(string blogIdentifier)
        {
            var request = new BlogInfoRequest(blogIdentifier);
            var result = _core.GetBlogInfo(_tumblrConfiguration, request);
            ThrowErrorsIfNeeded(result);
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
            blogInfo = result.Response.Blog;
            return result.Response.Posts;
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