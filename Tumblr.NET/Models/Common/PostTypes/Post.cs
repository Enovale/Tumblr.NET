using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;
using TumblrNET.Models.Common.BlogTypes;
using TumblrNET.Models.Common.PostTypes.LegacyPostTypes;

namespace TumblrNET.Models.Common.PostTypes
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(NpfPost), "blocks")]
    [JsonDerivedType(typeof(AnswerPost), "answer")]
    [JsonDerivedType(typeof(AudioPost), "audio")]
    [JsonDerivedType(typeof(ChatPost), "chat")]
    [JsonDerivedType(typeof(LinkPost), "link")]
    [JsonDerivedType(typeof(PhotoPost), "photo")]
    [JsonDerivedType(typeof(QuotePost), "quote")]
    [JsonDerivedType(typeof(VideoPost), "video")]
    [JsonDerivedType(typeof(TextPost), "text")]
    // TODO System.Text.Json seems incapable of handling multiple type definitions.
    //[JsonDerivedType(typeof(ChatPost), "conversation")]
    //[JsonDerivedType(typeof(TextPost), "regular")]
    public abstract class Post : TumblrResource
    {
        [JsonPropertyName("blog_name")]
        public required string BlogName { get; set; }
        
        [JsonPropertyName("id")]
        public required long Id { get; set; }
        
        [JsonPropertyName("id_string")]
        public required string IdStr { get; set; }
        
        [JsonPropertyName("genesis_post_id")]
        public string? GenesisId { get; set; }
        
        [JsonPropertyName("post_url")]
        public required string Url { get; set; }
        
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonAttributeEnumConverter<PostType>))]
        public required PostType Type { get; set; }
        
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(JsonTimestampConverter))]
        public required DateTimeOffset Timestamp { get; set; }
        
        [JsonPropertyName("date")]
        [JsonConverter(typeof(JsonGmtStringConverter))]
        public required DateTime Date { get; set; }
        
        [JsonPropertyName("format")]
        [JsonConverter(typeof(JsonAttributeEnumConverter<PostFormat>))]
        public PostFormat? Format { get; set; }
        
        [JsonPropertyName("reblog_key")]
        public required string ReblogKey { get; set; }
        
        [JsonPropertyName("tags")]
        public required string[] Tags { get; set; }

        // TODO Check if this is actually deserializing private fields
        [JsonPropertyName("bookmarklet")]
        private bool? _bookmarklet;

        public bool Bookmarklet
        {
            get => _bookmarklet ?? false;
            set => _bookmarklet = value;
        }

        [JsonPropertyName("mobile")]
        private bool? _mobile;

        public bool Mobile
        {
            get => _mobile ?? false;
            set => _mobile = value;
        }
        
        [JsonPropertyName("source_url")]
        public string? SourceUrl { get; set; }
        
        [JsonPropertyName("source_title")]
        public string? SourceTitle { get; set; }
        
        [JsonPropertyName("liked")]
        public bool? Liked { get; set; }
        
        [JsonPropertyName("state")]
        [JsonConverter(typeof(JsonAttributeEnumConverter<PostState>))]
        public required PostState State { get; set; }
        
        [JsonPropertyName("is_blocks_post_format")]
        public required bool IsNpfFormat { get; set; }
        
        [JsonPropertyName("muted")]
        public bool? Muted { get; set; }
        
        // TODO Possibly an edge case where this value is 0 to indicate an infinite mute
        [JsonPropertyName("mute_end_timestamp")]
        [JsonConverter(typeof(JsonTimestampConverter))]
        public DateTimeOffset? MuteEnd { get; set; }
        
        public Blog RetrieveBlog() => Client.GetBlog(BlogName);
    }
}