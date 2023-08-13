using System.Net;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Security.Authentication;
using System.Text.Json;
using TumblrNET.Extensions;
using TumblrNET.Models.Authentication;
using TumblrNET.Models.Requests;
using TumblrNET.Models.Requests.RequestTypes;
using TumblrNET.Models.Requests.RequestTypes.Blog;
using TumblrNET.Models.Requests.RequestTypes.User;
using TumblrNET.Models.Responses;
using TumblrNET.Models.Responses.ResponseTypes;
using TumblrNET.Models.Responses.ResponseTypes.Blog;
using TumblrNET.Models.Responses.ResponseTypes.User;

namespace TumblrNET
{
    internal class TumblrCore
    {
        private const string USER_AGENT = "Tumblr.NET";

        private readonly HttpClient _httpClient;
        
        public string? ConsumerKey { get; set; }
        
        public string? ConsumerSecret { get; set; }

        public OAuth2State? OAuthState { get; set; }
        
        public AuthenticationRequirement MaximumAvailableAuthentication
        {
            get
            {
                if (ConsumerKey != null && ConsumerSecret != null && OAuthState != null)
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

        public ResponseWrapper<UserInfoResponse> GetUserInfo(TumblrConfiguration config, UserInfoRequest request,
            UriParamSerializationOptions? options = null)
        {
            return SendAndDeserializeRequest<UserInfoRequest, UserInfoResponse>(config, HttpMethod.Get, request,
                options);
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

        public OAuth2State RequestOAuthAccessCode(TumblrConfiguration config, string code, string? redirectUri = null)
            => RequestOAuthAccessCodeAsync(config, code, redirectUri).Result;

        public async Task<OAuth2State> RequestOAuthAccessCodeAsync(TumblrConfiguration config, string code, string? redirectUri = null)
        {
            if (ConsumerKey == null || ConsumerSecret == null)
                throw new InvalidOperationException($"This client instance is missing a consumer secret. Please construct the {nameof(Tumblr)} client with a key and a secret.");
            
            var query = new List<KeyValuePair<string, string>>
            {
                new("grant_type", "authorization_code"),
                new("code", code),
                new("client_id", ConsumerKey),
                new("client_secret", ConsumerSecret)
            };
            
            if (redirectUri != null)
                query.Add(new("redirect_uri", redirectUri));
            
            var uri = new UriBuilder(config.ApiRoot + "/v2/oauth2/token" + "?" + query).ToString();
            var content = new FormUrlEncodedContent(query);
            var response = await _httpClient.PostAsync(uri, content);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new HttpRequestException("Unauthorized request.");
            }

            var responseStr = await response.Content.ReadAsStringAsync();
            var responseObj = JsonSerializer.Deserialize<OAuth2State>(responseStr);

            return responseObj ?? throw new SerializationException("Could not properly deserialize the authorization response.");
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
                        new AuthenticationHeaderValue("Bearer", OAuthState!.AccessToken);
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