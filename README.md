# Tumblr.NET
### An attempt at wrapping the Tumblr Neue Post Format (NPF) in Plain C#

## What's Implemented

- [x] Auth
  - [x] API Key
  - [x] OAuth
    - [x] OAuth login flow
    - [ ] XAuth (/oauth/access_token)
- [ ] Post Types
  - [x] NPF
  - [ ] Legacy Posts
- [x] Transport
  - [x] Models
    - [x] Generic Request Wrapper
    - [x] Generic Response Wrapper
  - [x] Json serializer
  - [x] Json de-serializer
- [x] User-facing API (Not actually done but the structure is in place, it's simply a matter of boilerplating everything)
  - [x] Raw API
    - [x] Request API
    - [x] Response API
  - [x] Abstracted API
    - [x] Request API
    - [x] Response API
  - [x] Object Oriented API (WIP)
- [x] API Wrapper
  - [x] Common Models
    - [ ] Activity
    - [x] Attribution
    - [x] Blocks
    - [x] Blog
    - [x] Media
    - [x] Post
      - [x] Note
    - [x] Tag
  - [ ] Request Types
    - [ ] Blog Methods
      - [x] Blog Info
      - [x] Blog Avatar
      - [x] Blog Blocks
      - [ ] Block Blog
      - [ ] Block Blog List
      - [ ] Remove Block
      - [x] Blog Likes
      - [x] Blog Following
      - [x] Blog Followers
      - [x] Blog Is Followed
      - [x] Blog Posts
      - [x] Blog Queue
      - [ ] Reorder Blog Queue
      - [ ] Shuffle Blog Queue
      - [x] Blog Drafts
      - [x] Blog Submissions
      - [x] Blog Activity
      - [ ] Create Post (Legacy)
      - [ ] Reblog Post (Legacy)
      - [ ] Create/Reblog Post (NPF)
      - [ ] Fetch Post (NPF)
      - [ ] Edit Post (NPF)
      - [ ] Delete Post
      - [ ] Mute Post
      - [x] Post Notes
    - [ ] User Methods
      - [x] User Info
      - [x] User Limits
      - [x] User Dash
      - [x] User Likes
      - [x] User Following
      - [ ] Follow Blog
      - [ ] Unfollow Blog
      - [ ] Like Post
      - [ ] Unlike Post
      - [ ] Tag Filtering
      - [ ] Content Filtering
    - [x] Tag Methods
      - [x] Posts with Tag
  - [x] Response Types
    - [x] Blog Methods
        - [x] Blog Info
        - [x] Blog Avatar
        - [x] Blog Blocks
        - [ ] Block Blog
        - [ ] Block Blog List
        - [ ] Remove Block
        - [x] Blog Likes
        - [x] Blog Following
        - [x] Blog Followers
        - [x] Blog Is Followed
        - [x] Blog Posts
        - [x] Blog Queue
        - [ ] Reorder Blog Queue
        - [ ] Shuffle Blog Queue
        - [x] Blog Drafts
        - [x] Blog Submissions
        - [x] Blog Activity
        - [ ] Create Post (Legacy)
        - [ ] Reblog Post (Legacy)
        - [ ] Create/Reblog Post (NPF)
        - [ ] Fetch Post (NPF)
        - [ ] Edit Post (NPF)
        - [ ] Delete Post
        - [ ] Mute Post
        - [x] Post Notes
    - [ ] User Methods
        - [x] User Info
        - [x] User Limits
        - [x] User Dash
        - [x] User Likes
        - [x] User Following
        - [ ] Follow Blog
        - [ ] Unfollow Blog
        - [ ] Like Post
        - [ ] Unlike Post
        - [ ] Tag Filtering
        - [ ] Content Filtering
    - [x] Tag Methods
        - [x] Posts with Tag