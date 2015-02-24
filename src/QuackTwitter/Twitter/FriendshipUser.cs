using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterFriendshipUser
	{
		[JsonProperty("name")]
		public string Name { get; private set; }
		[JsonProperty("screen_name")]
		public string ScreenName { get; private set; }
		[JsonProperty("id")]
		public long Id { get; private set; }
		[JsonProperty("id_str")]
		public string IdStr { get; private set; }
		[JsonProperty("connections")]
		public IList<TwitterFriendshipUserConnections> Connections { get; private set; }

		public enum TwitterFriendshipUserConnections
		{
			Following,
			FollowingRequested,
			FollowedBy,
			None,
			Blocking,
			Muting
		};
	}
}
