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
using TumblrNET.Models.Requests.RequestTypes.Tag;
using TumblrNET.Models.Requests.RequestTypes.User;
using TumblrNET.Models.Responses;
using TumblrNET.Models.Responses.ResponseTypes;
using TumblrNET.Models.Responses.ResponseTypes.BlogResponses;
using TumblrNET.Models.Responses.ResponseTypes.TagResponses;
using TumblrNET.Models.Responses.ResponseTypes.UserResponses;

namespace TumblrNET
{
    internal class TumblrCore
    {
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

        public async Task<ResponseWrapper<UserInfoResponse>> GetUserInfoAsync(TumblrConfiguration config,
            UserInfoRequest request, UriParamSerializationOptions? options = null)
        {
            return await SendAndDeserializeRequestAsync<UserInfoRequest, UserInfoResponse>(config, HttpMethod.Get,
                request, options);
        }

        public ResponseWrapper<UserInfoResponse> GetUserInfo(TumblrConfiguration config, UserInfoRequest request,
            UriParamSerializationOptions? options = null)
        {
            return SendAndDeserializeRequest<UserInfoRequest, UserInfoResponse>(config, HttpMethod.Get, request,
                options);
        }

        public async Task<ResponseWrapper<UserDashboardResponse>> GetUserDashboardAsync(TumblrConfiguration config,
            UserDashboardRequest request, UriParamSerializationOptions? options = null)
        {
            return await SendAndDeserializeRequestAsync<UserDashboardRequest, UserDashboardResponse>(config,
                HttpMethod.Get,
                request, options);
        }

        public ResponseWrapper<UserDashboardResponse> GetUserDashboard(TumblrConfiguration config,
            UserDashboardRequest request,
            UriParamSerializationOptions? options = null)
        {
            return SendAndDeserializeRequest<UserDashboardRequest, UserDashboardResponse>(config, HttpMethod.Get,
                request,
                options);
        }

        public async Task<ResponseWrapper<UserFollowingResponse>> GetUserFollowingAsync(TumblrConfiguration config,
            UserFollowingRequest request, UriParamSerializationOptions? options = null)
        {
            return await SendAndDeserializeRequestAsync<UserFollowingRequest, UserFollowingResponse>(config,
                HttpMethod.Get,
                request, options);
        }

        public ResponseWrapper<UserFollowingResponse> GetUserFollowing(TumblrConfiguration config,
            UserFollowingRequest request,
            UriParamSerializationOptions? options = null)
        {
            return SendAndDeserializeRequest<UserFollowingRequest, UserFollowingResponse>(config, HttpMethod.Get,
                request,
                options);
        }

        public async Task<ResponseWrapper<UserLikesResponse>> GetUserLikesAsync(TumblrConfiguration config,
            UserLikesRequest request, UriParamSerializationOptions? options = null)
        {
            return await SendAndDeserializeRequestAsync<UserLikesRequest, UserLikesResponse>(config,
                HttpMethod.Get,
                request, options);
        }

        public ResponseWrapper<UserLikesResponse> GetUserLikes(TumblrConfiguration config,
            UserLikesRequest request,
            UriParamSerializationOptions? options = null)
        {
            return SendAndDeserializeRequest<UserLikesRequest, UserLikesResponse>(config, HttpMethod.Get,
                request,
                options);
        }

        public async Task<ResponseWrapper<UserLimitResponse>> GetUserLimitAsync(TumblrConfiguration config,
            UserLimitsRequest request, UriParamSerializationOptions? options = null)
        {
            return await SendAndDeserializeRequestAsync<UserLimitsRequest, UserLimitResponse>(config,
                HttpMethod.Get,
                request, options);
        }

        public ResponseWrapper<UserLimitResponse> GetUserLimit(TumblrConfiguration config,
            UserLimitsRequest request,
            UriParamSerializationOptions? options = null)
        {
            return SendAndDeserializeRequest<UserLimitsRequest, UserLimitResponse>(config, HttpMethod.Get,
                request,
                options);
        }

        public async Task<ResponseWrapper<BlogInfoResponse>> GetBlogInfoAsync(TumblrConfiguration config,
            BlogInfoRequest request, UriParamSerializationOptions? options = null)
        {
            return await SendAndDeserializeRequestAsync<BlogInfoRequest, BlogInfoResponse>(config, HttpMethod.Get,
                request, options);
        }

        public ResponseWrapper<BlogInfoResponse> GetBlogInfo(TumblrConfiguration config, BlogInfoRequest request,
            UriParamSerializationOptions? options = null)
        {
            return SendAndDeserializeRequest<BlogInfoRequest, BlogInfoResponse>(config, HttpMethod.Get, request,
                options);
        }

        public async Task<ResponseWrapper<BlogPostsResponse>> GetBlogPostsAsync(TumblrConfiguration config,
            BlogPostsRequest request, UriParamSerializationOptions? options = null)
        {
            return await SendAndDeserializeRequestAsync<BlogPostsRequest, BlogPostsResponse>(config, HttpMethod.Get,
                request, options);
        }

        public ResponseWrapper<BlogPostsResponse> GetBlogPosts(TumblrConfiguration config,
            BlogPostsRequest request, UriParamSerializationOptions? options = null)
        {
            return SendAndDeserializeRequest<BlogPostsRequest, BlogPostsResponse>(config, HttpMethod.Get, request,
                options);
        }

        // See comment in Tumblr.GetBlogAvatarUrl
        public async Task<ResponseWrapper<BlogAvatarResponse>> GetBlogAvatarAsync(TumblrConfiguration config,
            BlogAvatarRequest request, UriParamSerializationOptions? options = null)
        {
            var response = await SendAndDeserializeRequestAsync<BlogAvatarRequest, BlogAvatarResponse>(config,
                HttpMethod.Get,
                request, options);
            return response;
        }

        public ResponseWrapper<BlogAvatarResponse> GetBlogAvatar(TumblrConfiguration config, BlogAvatarRequest request,
            UriParamSerializationOptions? options = null)
        {
            return SendAndDeserializeRequest<BlogAvatarRequest, BlogAvatarResponse>(config, HttpMethod.Get, request,
                options);
        }
        
        public async Task<ResponseWrapper<BlogBlockResponse>> GetBlogBlockListAsync(TumblrConfiguration config,
            BlogBlockRequest request, UriParamSerializationOptions? options = null)
        {
            var response = await SendAndDeserializeRequestAsync<BlogBlockRequest, BlogBlockResponse>(config,
                HttpMethod.Get,
                request, options);
            return response;
        }

        public ResponseWrapper<BlogBlockResponse> GetBlogBlockList(TumblrConfiguration config, BlogBlockRequest request,
            UriParamSerializationOptions? options = null)
        {
            return SendAndDeserializeRequest<BlogBlockRequest, BlogBlockResponse>(config, HttpMethod.Get, request,
                options);
        }
        
        public async Task<ResponseWrapper<TaggedPostsResponse>> GetPostsWithTagAsync(TumblrConfiguration config,
            TaggedPostsRequest request, UriParamSerializationOptions? options = null)
        {
            var response = await SendAndDeserializeRequestAsync<TaggedPostsRequest, TaggedPostsResponse>(config,
                HttpMethod.Get,
                request, options);
            return response;
        }

        public ResponseWrapper<TaggedPostsResponse> GetPostsWithTag(TumblrConfiguration config, TaggedPostsRequest request,
            UriParamSerializationOptions? options = null)
        {
            return SendAndDeserializeRequest<TaggedPostsRequest, TaggedPostsResponse>(config, HttpMethod.Get, request,
                options);
        }

        public OAuth2State RequestOAuthAccessCode(TumblrConfiguration config, string code, string? redirectUri = null)
            => RequestOAuthAccessCodeAsync(config, code, redirectUri).Result;

        public async Task<OAuth2State> RequestOAuthAccessCodeAsync(TumblrConfiguration config, string code,
            string? redirectUri = null)
        {
            if (ConsumerKey == null || ConsumerSecret == null)
                throw new InvalidOperationException(
                    $"This client instance is missing a consumer secret. Please construct the {nameof(Tumblr)} client with a key and a secret.");

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

            var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObj = await JsonSerializer.DeserializeAsync<OAuth2State>(responseStream);

            return responseObj ??
                   throw new SerializationException("Could not properly deserialize the authorization response.");
        }

        private async Task<ResponseWrapper<TResult>> SendAndDeserializeRequestAsync<TRequest, TResult>(
            TumblrConfiguration config, HttpMethod message, TRequest request,
            UriParamSerializationOptions? options = null) where TRequest : Request where TResult : Response
        {
            var result = await SendRequestAsync(config, message, request, options);
            return await DeserializeResponseAsync<TResult>(await result.Content.ReadAsStreamAsync());
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
            var requestMsg = GetAuthorizedRequest(config, message, request, options);
            return await _httpClient.SendAsync(requestMsg);
        }

        private HttpResponseMessage SendRequest<TRequest>(TumblrConfiguration config, HttpMethod message,
            TRequest request, UriParamSerializationOptions? options = null) where TRequest : Request
        {
            var requestMsg = GetAuthorizedRequest(config, message, request, options);
            return _httpClient.Send(requestMsg);
        }

        private HttpRequestMessage GetAuthorizedRequest<TRequest>(TumblrConfiguration config, HttpMethod message,
            TRequest request,
            UriParamSerializationOptions? options = null) where TRequest : Request
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

            return requestMsg;
        }
        
        private async Task<ResponseWrapper<TResult>> DeserializeResponseAsync<TResult>(Stream utf8Json) where TResult : Response
        {
            var response = await JsonSerializer.DeserializeAsync<ResponseWrapper<TResult>>(utf8Json);

            if (response == null)
                throw new SerializationException($"Failed to deserialize {typeof(TResult).Name}.");

            return response;
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