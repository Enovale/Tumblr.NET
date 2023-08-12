using System.Text.Json.Serialization;
using TumblrNET.Converters.Json;

namespace TumblrNET.Models.Common.ActivityTypes
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(LikeActivity), ACTIVITY_TYPE_LIKE)]
    [JsonDerivedType(typeof(ReplyActivity), ACTIVITY_TYPE_REPLY)]
    [JsonDerivedType(typeof(FollowActivity), ACTIVITY_TYPE_FOLLOW)]
    [JsonDerivedType(typeof(ReplyMentionActivity), ACTIVITY_TYPE_REPLY_MENTION)]
    [JsonDerivedType(typeof(PostMentionActivity), ACTIVITY_TYPE_POST_MENTION)]
    [JsonDerivedType(typeof(NakedReblogActivity), ACTIVITY_TYPE_NAKED_REBLOG)]
    [JsonDerivedType(typeof(ContentReblogActivity), ACTIVITY_TYPE_CONTENT_REBLOG)]
    [JsonDerivedType(typeof(AskActivity), ACTIVITY_TYPE_ASK)]
    [JsonDerivedType(typeof(AnsweredAskActivity), ACTIVITY_TYPE_ANSWERED_ASK)]
    [JsonDerivedType(typeof(NewGroupMemberActivity), ACTIVITY_TYPE_NEW_MEMBER)]
    [JsonDerivedType(typeof(PostAttributionActivity), ACTIVITY_TYPE_POST_ATTRIBUTION)]
    [JsonDerivedType(typeof(PostFlaggedActivity), ACTIVITY_TYPE_POST_FLAGGED)]
    [JsonDerivedType(typeof(PostAppealAcceptedActivity), ACTIVITY_TYPE_POST_APPEAL_ACCEPTED)]
    [JsonDerivedType(typeof(PostAppealRejectedActivity), ACTIVITY_TYPE_POST_APPEAL_REJECTED)]
    [JsonDerivedType(typeof(MissedPostActivity), ACTIVITY_TYPE_WHAT_YOU_MISSED)]
    [JsonDerivedType(typeof(ConversationalNoteActivity), ACTIVITY_TYPE_CONVERSATIONAL_NOTE)]
    public class Activity
    {
        internal const string ACTIVITY_TYPE_LIKE = "like";
        internal const string ACTIVITY_TYPE_REPLY = "reply";
        internal const string ACTIVITY_TYPE_FOLLOW = "follow";
        internal const string ACTIVITY_TYPE_REPLY_MENTION = "mention_in_reply";
        internal const string ACTIVITY_TYPE_POST_MENTION = "mention_in_post";
        internal const string ACTIVITY_TYPE_NAKED_REBLOG = "reblog_naked";
        internal const string ACTIVITY_TYPE_CONTENT_REBLOG = "reblog_with_content";
        internal const string ACTIVITY_TYPE_ASK = "ask";
        internal const string ACTIVITY_TYPE_ANSWERED_ASK = "answered_ask";
        internal const string ACTIVITY_TYPE_NEW_MEMBER = "new_group_blog_member";
        internal const string ACTIVITY_TYPE_POST_ATTRIBUTION = "post_attribution";
        internal const string ACTIVITY_TYPE_POST_FLAGGED = "post_flagged";
        internal const string ACTIVITY_TYPE_POST_APPEAL_ACCEPTED = "post_appeal_accepted";
        internal const string ACTIVITY_TYPE_POST_APPEAL_REJECTED = "post_appeal_rejected";
        internal const string ACTIVITY_TYPE_WHAT_YOU_MISSED = "what_you_missed";
        internal const string ACTIVITY_TYPE_CONVERSATIONAL_NOTE = "conversational_note";
        
        [JsonPropertyName("id")]
        public long Id { get; set; }
        
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(JsonTimestampConverter))]
        public DateTimeOffset Timestamp { get; set; }
        
        [JsonPropertyName("unread")]
        public bool Unread { get; set; }
    }
}