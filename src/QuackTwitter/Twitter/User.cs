using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterUser
	{
		[JsonProperty("id")]
		public long Id { get; private set; }
		[JsonProperty("id_str")]
		public string IdStr { get; private set; }
		[JsonProperty("name")]
		public string Name { get; private set; }
		[JsonProperty("screen_name")]
		public string ScreenName { get; private set; }
		[JsonProperty("location")]
		public string Location { get; private set; }
		[JsonProperty("profile_location")]
		public string ProfileLocation { get; private set; }
		[JsonProperty("description")]
		public string Description { get; private set; }
		[JsonProperty("url")]
		public string URL { get; private set; }
		[JsonProperty("entities")]
		public TwitterEntities Entities;
		[JsonProperty("protected")]
		public bool Protected { get; private set; }
		[JsonProperty("followers_count")]
		public int FollowersCount { get; private set; }
		[JsonProperty("friends_count")]
		public int FriendsCount { get; private set; }
		[JsonProperty("listed_count")]
		public int ListedCount { get; private set; }
		[JsonProperty("created_at")]
		public string CreatedAt { get; private set; }
		[JsonProperty("favourites_count")]
		public int FavouritesCount { get; private set; }
		[JsonProperty("utc_offset")]
		public int UTCOffset { get; private set; }
		[JsonProperty("time_zone")]
		public string TimeZone { get; private set; }
		[JsonProperty("geo_enabled")]
		public bool GeoEnabled { get; private set; }
		[JsonProperty("verified")]
		public bool Verified { get; private set; }
		[JsonProperty("statuses_count")]
		public int StatusesCount { get; private set; }
		[JsonProperty("lang")]
		public string Lang { get; private set; }
		[JsonProperty("status")]
		public TwitterStatus Status { get; private set; }
		[JsonProperty("contributors_enabled")]
		public bool ContributorsEnabled { get; private set; }
		[JsonProperty("is_translator")]
		public bool IsTranslator { get; private set; }
		[JsonProperty("is_translation_enabled")]
		public bool IsTranslationEnabled { get; private set; }
		[JsonProperty("profile_background_color")]
		public string ProfileBackgroundColor { get; private set; }
		[JsonProperty("profile_background_image_url")]
		public string ProfileBackgroundImageURL { get; private set; }
		[JsonProperty("profile_background_image_url_https")]
		public string ProfileBackgroundImageURLHTTPS { get; private set; }
		[JsonProperty("profile_background_tile")]
		public bool ProfileBackgroundTile { get; private set; }
		[JsonProperty("profile_image_url")]
		public string ProfileImageURL { get; private set; }
		[JsonProperty("profile_image_url_https")]
		public string ProfileImageURLHTTPS { get; private set; }
		[JsonProperty("profile_banner_url")]
		public string ProfileBannerURL { get; private set; }
		[JsonProperty("profile_link_color")]
		public string ProfileLinkColor { get; private set; }
		[JsonProperty("profile_sidebar_border_color")]
		public string ProfileSidebarBorderColor { get; private set; }
		[JsonProperty("profile_sidebar_fill_color")]
		public string ProfileSidebarFillColor { get; private set; }
		[JsonProperty("profile_text_color")]
		public string ProfileTextcolor { get; private set; }
		[JsonProperty("profile_use_background_image")]
		public bool ProfileUseBackgroundImage { get; private set; }
		[JsonProperty("default_profile")]
		public bool DefaultProfile { get; private set; }
		[JsonProperty("default_profile_image")]
		public bool DefaultProfileImage { get; private set; }
		[JsonProperty("following", NullValueHandling = NullValueHandling.Ignore)]
		public bool Following { get; private set; }
		[JsonProperty("follow_request_sent")]
		public bool FollowRequestSent { get; private set; }
		[JsonProperty("notifications", NullValueHandling = NullValueHandling.Ignore)]
		public bool Notifications { get; private set; }
		[JsonProperty("show_all_inline_media")]
		public bool ShowAllInlineMedia { get; private set; }
		[JsonProperty("withheld_in_countries")]
		public string WithheldInCountries { get; private set; }
		[JsonProperty("withheld_scope")]
		public string WithheldScope { get; private set; }
	}
}
