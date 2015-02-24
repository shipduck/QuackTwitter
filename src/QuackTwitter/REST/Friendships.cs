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
		public class TwitterFriendships
		{
			private Twitter instance;
			public TwitterFriendships(Twitter instance)
			{
				this.instance = instance;
			}

			public IList<long> NoRetweetsIds(Dictionary<string, string> parameters = null)
			{
				if (parameters.ContainsKey("stringify_ids"))
				{
					parameters["stringify_ids"] = "false";
				}
				return JsonConvert.DeserializeObject<IList<long>>(instance.Get(Constants.FriendshipsURL + "/no_retweets/ids.json", parameters));
			}

			public TwitterUserIds Incoming(Dictionary<string, string> parameters = null)
			{
				if (parameters.ContainsKey("stringify_ids"))
				{
					parameters["stringify_ids"] = "false";
				}
				return JsonConvert.DeserializeObject<TwitterUserIds>(instance.Get(Constants.FriendshipsURL + "/incoming.json", parameters));
			}

			public TwitterUserIds Outgoing(Dictionary<string, string> parameters = null)
			{
				if (parameters.ContainsKey("stringify_ids"))
				{
					parameters["stringify_ids"] = "false";
				}
				return JsonConvert.DeserializeObject<TwitterUserIds>(instance.Get(Constants.FriendshipsURL + "/outgoing.json", parameters));
			}

			public TwitterUser Create(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("screen_name")
					|| parameters.ContainsKey("user_id"))
				{
					return JsonConvert.DeserializeObject<TwitterUser>(instance.Post(Constants.FriendshipsURL + "/create.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

			public TwitterUser Destroy(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("screen_name")
					|| parameters.ContainsKey("user_id"))
				{
					return JsonConvert.DeserializeObject<TwitterUser>(instance.Post(Constants.FriendshipsURL + "/destroy.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

			public TwitterRelationship Update(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("screen_name")
					|| parameters.ContainsKey("user_id"))
				{
					return JsonConvert.DeserializeObject<Dictionary<string, TwitterRelationship>>(instance.Post(Constants.FriendshipsURL + "/update.json", parameters))["relationship"];
				}
				else
				{
					throw new Exception();
				}
			}

			public TwitterRelationship Show(Dictionary<string, string> parameters)
			{
				if ((parameters.ContainsKey("source_id") || parameters.ContainsKey("source_screen_name"))
					&& (parameters.ContainsKey("target_id") || parameters.ContainsKey("target_screen_name")))
				{
					return JsonConvert.DeserializeObject<Dictionary<string, TwitterRelationship>>(instance.Get(Constants.FriendshipsURL + "/show.json", parameters))["relationship"];
				}
				else
				{
					throw new Exception();
				}
			}

			public IList<TwitterFriendshipUser> Lookup(Dictionary<string, string> parameters)
			{
				if(parameters.ContainsKey("screen_name")
					|| parameters.ContainsKey("user_id"))
				{
					return JsonConvert.DeserializeObject<IList<TwitterFriendshipUser>>(instance.Get(Constants.FriendshipsURL + "/lookup.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}
		}

		public enum Friendships
		{
			NoRetweets,
			Incoming,
			Outgoing,
			Create,
			Destroy,
			Update,
			Show,
			Lookup
		};

		public dynamic REST(Friendships type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case Friendships.NoRetweets:
					return Get(Constants.FriendshipsURL + "/ids.json", parameters);
				case Friendships.Incoming:
					return Get(Constants.FriendshipsURL + "/incoming.json", parameters);
				case Friendships.Outgoing:
					return Get(Constants.FriendshipsURL + "/outgoing.json", parameters);
				case Friendships.Create:
					if (parameters.ContainsKey("screen_name") || parameters.ContainsKey("user_id"))
					{
						return Post(Constants.FriendshipsURL + "/create.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Friendships.Destroy:
					if (parameters.ContainsKey("screen_name") || parameters.ContainsKey("user_id"))
					{
						return Post(Constants.FriendshipsURL + "/destroy.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Friendships.Update:
					if (parameters.ContainsKey("screen_name") || parameters.ContainsKey("user_id"))
					{
						return Post(Constants.FriendshipsURL + "/update.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Friendships.Show:
					if ((parameters.ContainsKey("source_id") || parameters.ContainsKey("source_screen_name")
						&& parameters.ContainsKey("target_id") || parameters.ContainsKey("target_screen_name")))
					{
						return Post(Constants.FriendshipsURL + "/show.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Friendships.Lookup:
					return Get(Constants.FriendshipsURL + "/lookup.json", parameters);
				default:
					throw new Exception();
			}
		}
	}
}
