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
		public class TwitterMutes
		{
			private Twitter instance;
			public TwitterMutes(Twitter instance)
			{
				this.instance = instance;
			}

			public TwitterUser UsersCreate(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("screen_name")
					|| parameters.ContainsKey("user_id"))
				{
					return JsonConvert.DeserializeObject<TwitterUser>(instance.Post(Constants.MutesURL + "/users/create.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

			public TwitterUser UsersDestroy(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("screen_name")
					|| parameters.ContainsKey("user_id"))
				{
					return JsonConvert.DeserializeObject<TwitterUser>(instance.Post(Constants.MutesURL + "/users/destroy.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

			public TwitterUserIds UsersIds(Dictionary<string, string> parameters)
			{
				return JsonConvert.DeserializeObject<TwitterUserIds>(instance.Get(Constants.MutesURL + "/users/ids.json", parameters));
			}

			public TwitterUserList UsersList(Dictionary<string, string> parameters)
			{
				return JsonConvert.DeserializeObject<TwitterUserList>(instance.Get(Constants.MutesURL + "/users/list.json", parameters));
			}
		}
	}
}
