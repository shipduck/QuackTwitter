using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterRateLimitStatus
	{
		[JsonProperty("rate_limit_context")]
		public TwitterAccessToken RateLimitContext { get; private set; }
		[JsonProperty("resources")]
		public Dictionary<string, Dictionary<string, TwitterRateLimit>> Resources { get; private set; }

		public class TwitterAccessToken {
			[JsonProperty("access_token")]
			public string AccessToken { get; private set; }
		}

		public class TwitterRateLimit
		{
			[JsonProperty("limit")]
			public int Limit { get; private set; }
			[JsonProperty("remaining")]
			public int Remaining { get; private set; }
			[JsonProperty("reset")]
			public long Reset { get; private set; }
		}
	}
}
