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
		public TwitterUser MutesUsersCreate(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("screen_name")
				|| parameters.ContainsKey("user_id"))
			{
				return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.MutesURL + "/users/create.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterUser MutesUsersDestroy(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("screen_name")
				|| parameters.ContainsKey("user_id"))
			{
				return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.MutesURL + "/users/destroy.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterUserIds MutesUsersIds(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<TwitterUserIds>(GET(Constants.MutesURL + "/users/ids.json", parameters));
		}

		public TwitterUsers MutesUsersList(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<TwitterUsers>(GET(Constants.MutesURL + "/users/list.json", parameters));
		}
	}
}
