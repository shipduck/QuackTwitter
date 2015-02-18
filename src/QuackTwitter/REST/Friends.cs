using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class QuackTwitter
	{
		public enum Friends
		{
			Ids,
			List
		};

		public dynamic REST(Friends type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case Friends.Ids:
					if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
					{
						return Get(Constants.FriendsUrl + "/ids.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Friends.List:
					if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
					{
						return Get(Constants.FriendsUrl + "/list.json", parameters);
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
