using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class Twitter
	{
		public enum Followers
		{
			Ids,
			List
		};

		public dynamic REST(Followers type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case Followers.Ids:
					if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
					{
						return Get(Constants.FollowersUrl + "/ids.json", parameters);
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
