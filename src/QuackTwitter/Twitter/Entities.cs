using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class Entities
	{
		[JsonProperty("hashtags")]
		public IList<Hashtag> Hashtags { get; private set; }
		[JsonProperty("symbols")]
		public IList<Symbol> Symbols { get; private set; }
		[JsonProperty("user_mentions")]
		public IList<UserMention> UserMentions { get; private set; }
		[JsonProperty("urls")]
		public IList<_URL> URLs { get; private set; }
		[JsonProperty("media")]
		public IList<_Media> Media { get; private set; }
		[JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
		public _Description Description { get; private set; }

		public class Hashtag
		{
			[JsonProperty("text")]
			public string Text { get; private set; }
			[JsonProperty("indices")]
			public IList<int> Indices { get; private set; }
		}

		public class Symbol
		{
			[JsonProperty("text")]
			public string Text { get; private set; }
			[JsonProperty("indices")]
			public IList<int> Indices { get; private set; }
		}

		public class UserMention
		{
			[JsonProperty("screen_name")]
			public string ScreenName { get; private set; }
			[JsonProperty("name")]
			public string Name { get; private set; }
			[JsonProperty("id")]
			public long Id { get; private set; }
			[JsonProperty("id_str")]
			public string IdStr { get; private set; }
			[JsonProperty("indices")]
			public IList<int> Indices { get; private set; }
		}

		public class _URL
		{
			[JsonProperty("url")]
			public string URL { get; private set; }
			[JsonProperty("expanded_url")]
			public string ExpandedURL { get; private set; }
			[JsonProperty("display_url")]
			public string DisplayURL { get; private set; }
			[JsonProperty("indices")]
			public IList<int> Indices { get; private set; }
		}

		public class _Media
		{
			[JsonProperty("id")]
			public long Id { get; private set; }
			[JsonProperty("id_str")]
			public string IdStr { get; private set; }
			[JsonProperty("indices")]
			public IList<int> Indices { get; private set; }
			[JsonProperty("media_url")]
			public string MediaURL { get; private set; }
			[JsonProperty("media_url_https")]
			public string MediaURLHTTPS { get; private set; }
			[JsonProperty("url")]
			public string URL { get; private set; }
			[JsonProperty("display_url")]
			public string DisplayURL { get; private set; }
			[JsonProperty("expanded_url")]
			public string ExpandedURL { get; private set; }
			[JsonProperty("type")]
			public string Type { get; private set; }
			[JsonProperty("sizes")]
			public IDictionary<string, Size> Sizes { get; private set; }

			public class Size
			{
				[JsonProperty("w")]
				public int W { get; private set; }
				[JsonProperty("h")]
				public int H { get; private set; }
				[JsonProperty("resize")]
				public string Resize { get; private set; }
			}
		}

		public class _Description
		{
			[JsonProperty("urls")]
			public IList<_URL> URLs { get; private set; }
		}
	}
}
