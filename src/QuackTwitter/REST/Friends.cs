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
		public TwitterUserIds FriendsIds(Dictionary<string, string> parameters) {
			if(parameters.ContainsKey("user_id")
				|| parameters.ContainsKey("screen_name"))
			{
				return JsonConvert.DeserializeObject<TwitterUserIds>(GET(Constants.FriendsURL + "/ids.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterUsers FriendsList(Dictionary<string, string> parameters)
		{
			if(parameters.ContainsKey("user_id")
				|| parameters.ContainsKey("screen_name")) {
					return JsonConvert.DeserializeObject<TwitterUsers>(GET(Constants.FriendsURL + "/list.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}
	}
}
