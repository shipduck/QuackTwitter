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
		public IList<long> FriendshipsNoRetweetsIds(Dictionary<string, string> parameters = null)
		{
			if (parameters.ContainsKey("stringify_ids"))
			{
				parameters["stringify_ids"] = "false";
			}
			return JsonConvert.DeserializeObject<IList<long>>(GET(Constants.FriendshipsURL + "/no_retweets/ids.json", parameters));
		}

		public TwitterUserIds FriendshipsIncoming(Dictionary<string, string> parameters = null)
		{
			if (parameters.ContainsKey("stringify_ids"))
			{
				parameters["stringify_ids"] = "false";
			}
			return JsonConvert.DeserializeObject<TwitterUserIds>(GET(Constants.FriendshipsURL + "/incoming.json", parameters));
		}

		public TwitterUserIds FriendshipsOutgoing(Dictionary<string, string> parameters = null)
		{
			if (parameters.ContainsKey("stringify_ids"))
			{
				parameters["stringify_ids"] = "false";
			}
			return JsonConvert.DeserializeObject<TwitterUserIds>(GET(Constants.FriendshipsURL + "/outgoing.json", parameters));
		}

		public TwitterUser FriendshipsCreate(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("screen_name")
				|| parameters.ContainsKey("user_id"))
			{
				return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.FriendshipsURL + "/create.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterUser FriendshipsDestroy(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("screen_name")
				|| parameters.ContainsKey("user_id"))
			{
				return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.FriendshipsURL + "/destroy.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterRelationship FriendshipsUpdate(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("screen_name")
				|| parameters.ContainsKey("user_id"))
			{
				return JsonConvert.DeserializeObject<Dictionary<string, TwitterRelationship>>(POST(Constants.FriendshipsURL + "/update.json", parameters))["relationship"];
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterRelationship FriendshipsShow(Dictionary<string, string> parameters)
		{
			if ((parameters.ContainsKey("source_id") || parameters.ContainsKey("source_screen_name"))
				&& (parameters.ContainsKey("target_id") || parameters.ContainsKey("target_screen_name")))
			{
				return JsonConvert.DeserializeObject<Dictionary<string, TwitterRelationship>>(GET(Constants.FriendshipsURL + "/show.json", parameters))["relationship"];
			}
			else
			{
				throw new Exception();
			}
		}

		public IList<TwitterFriendshipUser> FriendshipsLookup(Dictionary<string, string> parameters)
		{
			if(parameters.ContainsKey("screen_name")
				|| parameters.ContainsKey("user_id"))
			{
				return JsonConvert.DeserializeObject<IList<TwitterFriendshipUser>>(GET(Constants.FriendshipsURL + "/lookup.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}
	}
}
