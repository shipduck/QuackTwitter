using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class Twitter
	{
		public class TwitterApplication
		{
			private Twitter instance;
			public TwitterApplication(Twitter instance)
			{
				this.instance = instance;
			}

			public TwitterRateLimitStatus RateLimitStatus(Dictionary<string, string> parameters)
			{
				return JsonConvert.DeserializeObject<TwitterRateLimitStatus>(instance.Get(Constants.ApplicationURL + "/rate_limit_status.json", parameters));
			}
		}
	}
}
