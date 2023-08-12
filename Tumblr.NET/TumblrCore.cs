using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Security.Authentication;
using System.Text.Json;
using TumblrNET.Extensions;
using TumblrNET.Models.Requests;
using TumblrNET.Models.Requests.RequestTypes;
using TumblrNET.Models.Requests.RequestTypes.Blog;
using TumblrNET.Models.Responses;
using TumblrNET.Models.Responses.ResponseTypes;
using TumblrNET.Models.Responses.ResponseTypes.Blog;

namespace TumblrNET
{
    internal class TumblrCore
    {
        private const string USER_AGENT = "Tumblr.NET";

        private readonly HttpClient _httpClient;
        
        public string? ConsumerKey { get; set; }
        
        public string? ConsumerSecret { get; set; }

        public string? OAuthAccessToken { get; set; }
        
        public string? OAuthRefreshToken { get; set; }
        
        public AuthenticationRequirement MaximumAvailableAuthentication
        {
            get
            {
                if (ConsumerKey != null && ConsumerSecret != null && OAuthAccessToken != null)
                    return AuthenticationRequirement.OAuth;
                
                if (ConsumerKey != null)
                    return AuthenticationRequirement.ApiKey;

                return AuthenticationRequirement.None;
            }
        }

        public TumblrCore(TumblrConfiguration? config = null)
        {
            config ??= new();
            var webRequestHandler = new HttpClientHandler();

            webRequestHandler.AllowAutoRedirect = false;
            _httpClient = new(webRequestHandler);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("User-Agent", config.UserAgent);
        }

        public async Task<ResponseWrapper<BlogInfoResponse>> GetBlogInfoAsync(TumblrConfiguration config,
            BlogInfoRequest request, UriParamSerializationOptions? options = null)
        {
            return await SendAndDeserializeRequestAsync<BlogInfoRequest, BlogInfoResponse>(config, HttpMethod.Get,
                request, options);
        }

        public async Task<ResponseWrapper<BlogPostsResponse>> GetBlogPostsAsync(TumblrConfiguration config,
            BlogPostsRequest request, UriParamSerializationOptions? options = null)
        {
            return await SendAndDeserializeRequestAsync<BlogPostsRequest, BlogPostsResponse>(config, HttpMethod.Get,
                request, options);
        }

        public ResponseWrapper<BlogInfoResponse> GetBlogInfo(TumblrConfiguration config, BlogInfoRequest request,
            UriParamSerializationOptions? options = null)
        {
            return SendAndDeserializeRequest<BlogInfoRequest, BlogInfoResponse>(config, HttpMethod.Get, request,
                options);
        }

        // This will return the URL in json form when OAuthed but we can get it regardless by checking the Location header.
        public async Task<HttpResponseMessage> GetBlogAvatarAsync(TumblrConfiguration config,
            BlogAvatarRequest request, UriParamSerializationOptions? options = null)
        {
            var response = await SendRequestAsync(config, HttpMethod.Get, request, options);
            return response;
        }

        public HttpResponseMessage GetBlogAvatar(TumblrConfiguration config, BlogAvatarRequest request,
            UriParamSerializationOptions? options = null)
        {
            var response = SendRequest(config, HttpMethod.Get, request, options);
            return response;
        }

        public ResponseWrapper<BlogPostsResponse> GetBlogPosts(TumblrConfiguration config,
            BlogPostsRequest request, UriParamSerializationOptions? options = null)
        {
            return SendAndDeserializeRequest<BlogPostsRequest, BlogPostsResponse>(config, HttpMethod.Get, request,
                options);
        }

        private async Task<ResponseWrapper<TResult>> SendAndDeserializeRequestAsync<TRequest, TResult>(
            TumblrConfiguration config, HttpMethod message, TRequest request,
            UriParamSerializationOptions? options = null) where TRequest : Request where TResult : Response
        {
            var result = await SendRequestAsync(config, message, request, options);
            return DeserializeResponse<TResult>(await result.Content.ReadAsStringAsync());
        }

        private ResponseWrapper<TResult> SendAndDeserializeRequest<TRequest, TResult>(TumblrConfiguration config,
            HttpMethod message, TRequest request, UriParamSerializationOptions? options = null)
            where TRequest : Request where TResult : Response
        {
            var result = SendRequest(config, message, request, options);
            return DeserializeResponse<TResult>(result.Content.ReadAsStringAsync().Result);
        }

        private async Task<HttpResponseMessage> SendRequestAsync<TRequest>(TumblrConfiguration config,
            HttpMethod message, TRequest request, UriParamSerializationOptions? options = null) where TRequest : Request
        {
            var uri = GetRequestUri(config, request, options);
            var requestMsg = new HttpRequestMessage(message, uri);
            return await _httpClient.SendAsync(requestMsg);
        }

        private HttpResponseMessage SendRequest<TRequest>(TumblrConfiguration config, HttpMethod message,
            TRequest request, UriParamSerializationOptions? options = null) where TRequest : Request
        {
            var uri = GetRequestUri(config, request, options);
            var requestMsg = new HttpRequestMessage(message, uri);

            if (request.Auth >= AuthenticationRequirement.OAuth)
            {
                if (MaximumAvailableAuthentication >= AuthenticationRequirement.OAuth)
                    requestMsg.Headers.Authorization =
                        new AuthenticationHeaderValue("Bearer", OAuthAccessToken);
                else
                    throw new AuthenticationException(
                        "This request requires OAuth authentication but the configuration is missing proper OAuth login details.");
            }

            return _httpClient.Send(requestMsg);
        }

        private ResponseWrapper<TResult> DeserializeResponse<TResult>(string json) where TResult : Response
        {
            var response = JsonSerializer.Deserialize<ResponseWrapper<TResult>>(json);

            if (response == null)
                throw new SerializationException($"Failed to deserialize {typeof(TResult).Name}.");

            return response;
        }

        public string GetRequestUri(TumblrConfiguration config, Request request,
            UriParamSerializationOptions? options = null)
        {
            var uriParams = request.GetParams(options);

            if (request.Auth >= AuthenticationRequirement.ApiKey)
            {
                if (MaximumAvailableAuthentication >= AuthenticationRequirement.ApiKey)
                    uriParams.AddWithConverters("api_key", ConsumerKey, options);
                else
                    throw new AuthenticationException(
                        "This request requires an API Key to authenticate but one was not provided.");
            }

            uriParams.AddWithConverters("npf", "true", options);
            var builder = new UriBuilder(config.ApiRoot + request.ApiPath + "?" + uriParams);
            return builder.ToString();
        }
    }
}