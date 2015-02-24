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
		public class TwitterFriends
		{
			private Twitter instance;
			public TwitterFriends(Twitter instance)
			{
				this.instance = instance;
			}

			public TwitterUserIds Ids(Dictionary<string, string> parameters) {
				if(parameters.ContainsKey("user_id")
					|| parameters.ContainsKey("screen_name"))
				{
					return JsonConvert.DeserializeObject<TwitterUserIds>(instance.Get(Constants.FriendsURL + "/ids.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

			public TwitterUserList List(Dictionary<string, string> parameters)
			{
				if(parameters.ContainsKey("user_id")
					|| parameters.ContainsKey("screen_name")) {
						return JsonConvert.DeserializeObject<TwitterUserList>(instance.Get(Constants.FriendsURL + "/list.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}
		}
	}
}
