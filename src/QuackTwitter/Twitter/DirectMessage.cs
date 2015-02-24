using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterDirectMessage
	{
		[JsonProperty("id")]
		public long Id { get; private set; }
		[JsonProperty("id_str")]
		public string IdStr { get; private set; }
		[JsonProperty("text")]
		public string Text { get; private set; }
		[JsonProperty("sender")]
		public TwitterUser Sender { get; private set; }
		[JsonProperty("sender_id")]
		public long SenderId { get; private set; }
		[JsonProperty("sender_id_str")]
		public string SenderIdStr { get; private set; }
		[JsonProperty("sender_screen_name")]
		public string SenderScreenName { get; private set; }
		[JsonProperty("recipient")]
		public TwitterUser Recipient { get; private set; }
		[JsonProperty("recipient_id")]
		public long RecipientId { get; private set; }
		[JsonProperty("recipient_id_str")]
		public string RecipientIdStr { get; private set; }
		[JsonProperty("recipient_screen_name")]
		public string RecipientScreenName { get; private set; }
		[JsonProperty("created_at")]
		public string CreatedAt { get; private set; }
		[JsonProperty("entities")]
		public TwitterEntities Entities { get; private set; }
	}
}
