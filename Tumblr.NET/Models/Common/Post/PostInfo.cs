using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;
using TumblrNET.Models.Common.Blocks;
using TumblrNET.Models.Common.Blocks.LayoutTypes;
using TumblrNET.Models.Common.Media;

namespace TumblrNET.Models.Common.Post
{
    public class PostInfo
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
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public required DateTime Date { get; set; }
        
        [JsonPropertyName("format")]
        [JsonConverter(typeof(JsonAttributeEnumConverter<PostFormat>))]
        public PostFormat? Format { get; set; }
        
        [JsonPropertyName("reblog_key")]
        public required string ReblogKey { get; set; }
        
        [JsonPropertyName("tags")]
        public required string[] Tags { get; set; }

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
        
        // NPF
        [JsonPropertyName("content")]
        public Block[]? Content { get; set; }
        
        [JsonPropertyName("layout")]
        public Layout[]? Layout { get; set; }
        
        [JsonPropertyName("trail")]
        public TrailItem[]? Trail { get; set; }
        
        // TODO Maybe use polymorphism for legacy posts??? idk
        // Legacy Text Posts
        [JsonPropertyName("title")]
        public string? LegacyTitle { get; set; }
        
        [JsonPropertyName("body")]
        public string? LegacyBody { get; set; }
        
        // Legacy Photo Posts
        [JsonPropertyName("caption")]
        public string? LegacyCaption { get; set; }
        
        [JsonPropertyName("width")]
        public int? LegacyWidth { get; set; }
        
        [JsonPropertyName("height")]
        public int? LegacyHeight { get; set; }
        
        [JsonPropertyName("photos")]
        public LegacyPhotos[]? LegacyPhotos { get; set; }
        
        // Legacy Quote Posts
        [JsonPropertyName("text")]
        public string? LegacyText { get; set; }
        
        [JsonPropertyName("source")]
        public string? LegacySource { get; set; }
        
        // Legacy Link Posts
        // Title is already defined
        
        [JsonPropertyName("description")]
        public string? LegacyDescription { get; set; }
        
        // Url is already defined
        
        [JsonPropertyName("link_author")]
        public string? LegacyLinkAuthor { get; set; }
        
        [JsonPropertyName("excerpt")]
        public string? LegacyExcerpt { get; set; }
        
        [JsonPropertyName("publisher")]
        public string? LegacyPublisher { get; set; }
        
        // Photos is already defined
        
        // Legacy Chat Posts
        // Title is already defined
        
        // Body is already defined
        
        [JsonPropertyName("dialogue")]
        public DialogueInfo[]? LegacyDialogue { get; set; }
        
        // Legacy Audio Posts
        // Caption is already defined
        
        [JsonPropertyName("player")]
        public string? LegacyPlayerHtml { get; set; }
        
        [JsonPropertyName("plays")]
        public int? LegacyPlays { get; set; }
        
        [JsonPropertyName("album_art")]
        public string? LegacyAlbumArt { get; set; }
        
        [JsonPropertyName("artist")]
        public string? LegacyArtist { get; set; }
        
        [JsonPropertyName("album")]
        public string? LegacyAlbum { get; set; }
        
        [JsonPropertyName("track_name")]
        public string? LegacyTrackName { get; set; }
        
        [JsonPropertyName("track_number")]
        public int? LegacyTrackNumber { get; set; }
        
        [JsonPropertyName("year")]
        public int? LegacyYear { get; set; }
        
        // Legacy Video Posts
        // Caption is already defined
        
        // TODO player is reused so fuck it and fuck this hate tumblr
        
        // Width is already defined
        
        [JsonPropertyName("embed_code")]
        public string? LegacyEmbedHtml { get; set; }
        
        // Legacy Answer Posts
        [JsonPropertyName("asking_name")]
        public string? LegacyAskingName { get; set; }
        
        [JsonPropertyName("asking_url")]
        public string? LegacyAskingUrl { get; set; }
        
        [JsonPropertyName("question")]
        public string? LegacyQuestion { get; set; }
        
        [JsonPropertyName("answer")]
        public string? LegacyAnswer { get; set; }
    }
}