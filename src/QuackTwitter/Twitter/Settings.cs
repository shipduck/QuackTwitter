using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QuackTwitter
{
	public class TwitterSettings
	{
		[JsonProperty("time_zone")]
		public TwitterTimeZone TimeZone { get; private set; }
		[JsonProperty("protected")]
		public bool Protected { get; private set; }
		[JsonProperty("screen_name")]
		public string ScreenName { get; private set; }
		[JsonProperty("always_use_https")]
		public bool AlwaysUseHTTPS { get; private set; }
		[JsonProperty("use_cookie_personalization")]
		public bool UseCookiePersonalization { get; private set; }
		[JsonProperty("sleep_time")]
		public TwitterSleepTime SleepTime { get; private set; }
		[JsonProperty("geo_enabled")]
		public bool GeoEnabled { get; private set; }
		[JsonProperty("language")]
		public string Language { get; private set; }
		[JsonProperty("discoverable_by_email")]
		public bool DiscoverableByEmail { get; private set; }
		[JsonProperty("discoverable_by_mobile_phone")]
		public bool DiscoverableByMobilePhone { get; private set; }
		[JsonProperty("display_sensitive_media")]
		public bool DisplaySensitiveMedia { get; private set; }
		[JsonProperty("trend_location")]
		public IList<TwitterTrendLocation> TrendLocation { get; private set; }

		public class TwitterTimeZone
		{
			[JsonProperty("name")]
			public string Name { get; private set; }
			[JsonProperty("utc_offset")]
			public int UTCOffset { get; private set; }
			[JsonProperty("tzinfo_name")]
			public string TZInfoName { get; private set; }
		}

		public class TwitterSleepTime
		{
			[JsonProperty("enabled")]
			public bool Enabled { get; private set; }
			[JsonProperty("end_time")]
			public int EndTime { get; private set; }
			[JsonProperty("start_time")]
			public int StartTime { get; private set; }
		}
	}
}
