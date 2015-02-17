using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class Twitter
	{
		public enum Application
		{
			RateLimitStatus
		};

		public dynamic REST(Application type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case Application.RateLimitStatus:
					return Get(Constants.ApplicationUrl + "/rate_limit_status.json", parameters);
				default:
					throw new Exception();
			}
		}
	}
}
