using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterList
	{
		[JsonProperty("id")]
		public long Id { get; private set; }
		[JsonProperty("id_str")]
		public string IdStr { get; private set; }
		[JsonProperty("name")]
		public string Name { get; private set; }
		[JsonProperty("uri")]
		public string URI { get; private set; }
		[JsonProperty("subscriber_count")]
		public int SubscriberCount { get; private set; }
		[JsonProperty("member_count")]
		public int MemberCount { get; private set; }
		[JsonProperty("mode")]
		public string Mode { get; private set; }
		[JsonProperty("description")]
		public string Description { get; private set; }
		[JsonProperty("slug")]
		public string Slug { get; private set; }
		[JsonProperty("full_name")]
		public string FullName { get; private set; }
		[JsonProperty("created_at")]
		public string CreatedAt { get; private set; }
		[JsonProperty("following")]
		public bool Following { get; private set; }
		[JsonProperty("user")]
		public TwitterUser User { get; private set; }
	}
}
