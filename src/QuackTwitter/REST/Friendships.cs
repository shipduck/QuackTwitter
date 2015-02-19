using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class QuackTwitter
	{
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
