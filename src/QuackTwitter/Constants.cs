using System;

namespace QuackTwitter
{
	class Constants
	{
		public const String BaseURL = "https://api.twitter.com/1.1";
		public const String OAuthURL = "https://api.twitter.com/oauth/authorize";
		public const String StatusesURL = BaseURL + "/statuses";
		public const String MediaURL = "https://upload.twitter.com/1.1/media";
		public const String DirectMessagesURL = BaseURL + "/direct_messages";
		public const String SearchURL = BaseURL + "/search";
		public const String FriendshipsURL = BaseURL + "/friendships";
		public const String FriendsURL = BaseURL + "/friends";
		public const String FollowersURL = BaseURL + "/followers";
		public const String AccountURL = BaseURL + "/account";
		public const String BlocksURL = BaseURL + "/blocks";
		public const String UsersURL = BaseURL + "/users";
		public const String MutesURL = BaseURL + "/mutes";
		public const String FavoritesURL = BaseURL + "/favorites";
		public const String ListsURL = BaseURL + "/lists";
		public const String SavedSearchesURL = BaseURL + "/saved_searches";
		public const String GeoURL = BaseURL + "/geo";
		public const String TrendsURL = BaseURL + "/trends";
		public const String ApplicationURL = BaseURL + "/application";
		public const String HelpURL = BaseURL + "/help";
	}
}
