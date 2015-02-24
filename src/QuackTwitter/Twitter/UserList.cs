using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterUserList
	{
		[JsonProperty("previous_cursor")]
		public long PreviousCursor { get; private set; }
		[JsonProperty("previous_cursor_str")]
		public string PreviousCursorStr { get; private set; }
		[JsonProperty("next_cursor")]
		public long NextCursor { get; private set; }
		[JsonProperty("next_cursor_str")]
		public string NextCursorStr { get; private set; }
		[JsonProperty("users")]
		public IList<TwitterUser> Users { get; private set; }
	}
}
