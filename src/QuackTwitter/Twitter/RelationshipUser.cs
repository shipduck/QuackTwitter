using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterRelationshipUser
	{
		[JsonProperty("id")]
		public long Id { get; private set; }
		[JsonProperty("id_str")]
		public string IdStr { get; private set; }
		[JsonProperty("screen_name")]
		public string ScreenName { get; private set; }
		[JsonProperty("following")]
		public bool Following { get; private set; }
		[JsonProperty("followed_by")]
		public bool FollowedBy { get; private set; }
		[JsonProperty("following_received")]
		public bool FollowingReceived { get; private set; }
		[JsonProperty("following_requested")]
		public bool FollowingRequested { get; private set; }
		[JsonProperty("notifications_enabled")]
		public bool NotificationsEnabled { get; private set; }
		[JsonProperty("can_dm")]
		public bool CanDM { get; private set; }
		[JsonProperty("blocking")]
		public bool Blocking { get; private set; }
		[JsonProperty("want_retweets")]
		public bool WantRetweets { get; private set; }
		[JsonProperty("all_replies")]
		public bool AllReplies { get; private set; }
		[JsonProperty("marked_spam")]
		public bool MarkedSpam { get; private set; }
	}
}
