using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterTrends
	{
		[JsonProperty("trends")]
		public IList<TwitterTrend> Trends { get; private set; }
		[JsonProperty("as_of")]
		public string AsOf { get; private set; }
		[JsonProperty("created_at")]
		public string CreatedAt { get; private set; }
		[JsonProperty("location")]
		public IList<TwitterTrendsLocation> Locations { get; private set; }

		public class TwitterTrend
		{
			[JsonProperty("name")]
			public string Name { get; private set; }
			[JsonProperty("query")]
			public string Query { get; private set; }
			[JsonProperty("url")]
			public string URL { get; private set; }
			[JsonProperty("promoted_content")]
			public bool PromotedContent { get; private set; }
		}

		public class TwitterTrendsLocation
		{
			[JsonProperty("name")]
			public string Name { get; private set; }
			[JsonProperty("woeid")]
			public long WOEId { get; private set; }
		}
	}
}
