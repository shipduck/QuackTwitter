using System;

namespace QuackTwitter
{
    class Constants
    {
        public const String BaseUrl = "https://api.twitter.com/1.1";
        public const String OAuthUrl = "https://api.twitter.com/oauth/authorize";
        public const String StatusesUrl = BaseUrl + "/statuses";
        public const String MediaUrl = "https://upload.twitter.com/1.1/media";
        public const String DirectMessagesUrl = BaseUrl + "/direct_messages";
        public const String SearchUrl = BaseUrl + "/search";
        public const String FriendshipsUrl = BaseUrl + "/friendships";
        public const String FriendsUrl = BaseUrl + "/friends";
        public const String FollowersUrl = BaseUrl + "/followers";
        public const String AccountUrl = BaseUrl + "/account";
        public const String BlocksUrl = BaseUrl + "/blocks";
        public const String UsersUrl = BaseUrl + "/users";
        public const String MutesUrl = BaseUrl + "/mutes";
        public const String FavoritesUrl = BaseUrl + "/favorites";
        public const String ListsUrl = BaseUrl + "/lists";
        public const String SavedSearchesUrl = BaseUrl + "/saved_searches";
        public const String GeoUrl = BaseUrl + "/geo";
        public const String TrendsUrl = BaseUrl + "/trends";
        public const String ApplicationUrl = BaseUrl + "/application";
        public const String HelpUrl = BaseUrl + "/help";
    }
}
