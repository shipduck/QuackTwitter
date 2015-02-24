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
		public TwitterRateLimitStatus ApplicationRateLimitStatus(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<TwitterRateLimitStatus>(GET(Constants.ApplicationURL + "/rate_limit_status.json", parameters));
		}
	}
}
