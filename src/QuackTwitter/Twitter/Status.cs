using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterStatus
	{
		[JsonProperty("created_at")]
		public string CreatedAt { get; private set; }
		[JsonProperty("id")]
		public long Id { get; private set; }
		[JsonProperty("id_str")]
		public string IdStr { get; private set; }
		[JsonProperty("text")]
		public string Text { get; private set; }
		[JsonProperty("source")]
		public string Source { get; private set; }
		[JsonProperty("truncated")]
		public bool Truncated { get; private set; }
		[JsonProperty("in_reply_to_status_id", NullValueHandling = NullValueHandling.Ignore)]
		public long InReplyToStatusId { get; private set; }
		[JsonProperty("in_reply_to_status_id_str")]
		public string InReplyToStatusIdStr { get; private set; }
		[JsonProperty("in_reply_to_user_id", NullValueHandling = NullValueHandling.Ignore)]
		public long InReplyToUserId { get; private set; }
		[JsonProperty("in_reply_to_user_id_str")]
		public string InReplyToUserIdStr { get; private set; }
		[JsonProperty("in_reply_to_screen_name")]
		public string InReplyToScreenName { get; private set; }
		[JsonProperty("user")]
		public TwitterUser User { get; private set; }
		[JsonProperty("geo")]
		public TwitterGeo Geo { get; private set; }
		[JsonProperty("coordinates")]
		public TwitterCoordinates Coordiates { get; private set; }
		[JsonProperty("place")]
		public TwitterPlace Place { get; private set; }
		[JsonProperty("contributors")]
		public IList<TwitterContributor> Contributors { get; private set; }
		[JsonProperty("retweeted_status")]
		public TwitterStatus RetweetedStatus { get; private set; }
		[JsonProperty("retweet_count")]
		public int RetweetCount { get; private set; }
		[JsonProperty("favorite_count")]
		public int FavoriteCount { get; private set; }
		[JsonProperty("entities")]
		public TwitterEntities Entities { get; private set; }
		[JsonProperty("extended_entities")]
		public TwitterEntities ExtendedEntities { get; private set; }
		[JsonProperty("favorited")]
		public bool Favorited { get; private set; }
		[JsonProperty("retweeted")]
		public bool Retweeted { get; private set; }
		[JsonProperty("possibly_sensitive")]
		public bool PossiblySensitive { get; private set; }
		[JsonProperty("possibly_sensitive_appealable")]
		public bool PossiblySensitiveAppealable { get; private set; }
		[JsonProperty("lang")]
		public string Lang { get; private set; }
//		[JsonProperty("annoations")]
//		public IList<Annotation> Annotations { get; private set; }
		[JsonProperty("current_user_retweet")]
		public TwitterCurrentUserRetweet CurrentUserRetweet { get; private set; }
		[JsonProperty("filter_level")]
		public string FilterLevel { get; private set; }
//		[JsonProperty("scopes")]
//		public Dictionary<string, bool> Scopes { get; privates set; }
		[JsonProperty("withheld_copyright")]
		public bool WithheldCopyright { get; private set; }
		[JsonProperty("withheld_in_countries")]
		public IList<string> WithheldInCountries { get; private set; }
		[JsonProperty("withheld_scope")]
		public string WithheldScope { get; private set; }

		public class TwitterGeo {
			[JsonProperty("type")]
			public string Type { get; private set; }
			[JsonProperty("coordinates")]
			public IList<float> Coordiates { get; private set; }
		}

		public class TwitterCoordinates
		{
			[JsonProperty("type")]
			public string Type { get; private set; }
			[JsonProperty("coordiates")]
			public IList<float> Coordinates { get; private set; }
		}

		public class TwitterContributor
		{
			[JsonProperty("id")]
			public long id { get; private set; }
			[JsonProperty("id_str")]
			public string IdStr { get; private set; }
			[JsonProperty("screen_name")]
			public string ScreenName { get; private set; }
		}

		public class TwitterCurrentUserRetweet {
			[JsonProperty("id")]
			public long Id { get; private set; }
			[JsonProperty("id_str")]
			public string IdStr { get; private set; }
		}
	}
}
