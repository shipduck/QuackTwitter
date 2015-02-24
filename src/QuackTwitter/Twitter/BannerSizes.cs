using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterBannerSizes
	{
		[JsonProperty("sizes")]
		public Dictionary<string, TwitterBannerSize> Size { get; private set; }

		public class TwitterBannerSize
		{
			[JsonProperty("h")]
			public int Height { get; private set; }
			[JsonProperty("w")]
			public int Width { get; private set; }
			[JsonProperty("url")]
			public string URL { get; private set; }
		}
	}
}
