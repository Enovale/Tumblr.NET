using TumblrNET.Attributes;

namespace TumblrNET.Models.Common.ActivityTypes
{
    public enum ActivityType
    {
        [EnumValueName(Activity.ACTIVITY_TYPE_LIKE)]
        Like,
        
        [EnumValueName(Activity.ACTIVITY_TYPE_REPLY)]
        Reply,
        
        [EnumValueName(Activity.ACTIVITY_TYPE_FOLLOW)]
        Follow,
        
        [EnumValueName(Activity.ACTIVITY_TYPE_REPLY_MENTION)]
        MentionInReply,
        
        [EnumValueName(Activity.ACTIVITY_TYPE_POST_MENTION)]
        MentionInPost,
        
        [EnumValueName(Activity.ACTIVITY_TYPE_NAKED_REBLOG)]
        NakedReblog,
        
        [EnumValueName(Activity.ACTIVITY_TYPE_CONTENT_REBLOG)]
        ContentReblog,
        
        [EnumValueName(Activity.ACTIVITY_TYPE_ASK)]
        Ask,
        
        [EnumValueName(Activity.ACTIVITY_TYPE_ANSWERED_ASK)]
        AnsweredAsk,
        
        [EnumValueName(Activity.ACTIVITY_TYPE_NEW_MEMBER)]
        NewGroupMember,
        
        [EnumValueName(Activity.ACTIVITY_TYPE_POST_ATTRIBUTION)]
        PostAttribution,
        
        [EnumValueName(Activity.ACTIVITY_TYPE_POST_FLAGGED)]
        PostFlagged,
        
        [EnumValueName(Activity.ACTIVITY_TYPE_POST_APPEAL_ACCEPTED)]
        PostAppealAccepted,
        
        [EnumValueName(Activity.ACTIVITY_TYPE_POST_APPEAL_REJECTED)]
        PostAppealRejected,
        
        [EnumValueName(Activity.ACTIVITY_TYPE_WHAT_YOU_MISSED)]
        WhatYouMissed,
        
        [EnumValueName(Activity.ACTIVITY_TYPE_CONVERSATIONAL_NOTE)]
        ConversationalNote
    }
}