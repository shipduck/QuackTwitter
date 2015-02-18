using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class QuackTwitter
	{
		public enum Search
		{
			Tweets
		};

		public dynamic REST(Search type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case Search.Tweets:
					if (parameters.ContainsKey("q"))
					{
						return Get(Constants.SearchUrl + "/tweets.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				default:
					throw new Exception();
			}
		}
	}
}
