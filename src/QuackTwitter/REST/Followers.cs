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
		public class TwitterFollowers
		{
			private Twitter instance;
			public TwitterFollowers(Twitter instance)
			{
				this.instance = instance;
			}

			public TwitterUserIds Ids(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("user_id")
					|| parameters.ContainsKey("screen_name"))
				{
					return JsonConvert.DeserializeObject<TwitterUserIds>(instance.Get(Constants.FollowersURL + "/ids.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

			public TwitterUserList List(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("user_id")
					|| parameters.ContainsKey("screen_name"))
				{
					return JsonConvert.DeserializeObject<TwitterUserList>(instance.Get(Constants.FollowersURL + "/list.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}
		}
	}
}
