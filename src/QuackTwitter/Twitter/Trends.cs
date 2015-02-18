using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class Twitter
	{
		public enum Trends
		{
			Place,
			Available,
			Closest
		};

		public dynamic REST(Trends type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case Trends.Place:
					if (parameters.ContainsKey("id"))
					{
						return Get(Constants.TrendsUrl + "/place.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Trends.Available:
					return Get(Constants.TrendsUrl + "/available.json", parameters);
				case Trends.Closest:
					if (parameters.ContainsKey("lat") && parameters.ContainsKey("long"))
					{
						return Get(Constants.TrendsUrl + "/closest.json", parameters);
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
