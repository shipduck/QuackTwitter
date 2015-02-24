using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterEntities
	{
		[JsonProperty("hashtags")]
		public IList<TwitterHashtag> Hashtags { get; private set; }
		[JsonProperty("symbols")]
		public IList<TwitterSymbol> Symbols { get; private set; }
		[JsonProperty("user_mentions")]
		public IList<TwitterUserMention> UserMentions { get; private set; }
		[JsonProperty("urls")]
		public IList<TwitterURL> URLs { get; private set; }
		[JsonProperty("media")]
		public IList<TwitterMedia> Media { get; private set; }
		[JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
		public TwitterDescription Description { get; private set; }

		public class TwitterHashtag
		{
			[JsonProperty("text")]
			public string Text { get; private set; }
			[JsonProperty("indices")]
			public IList<int> Indices { get; private set; }
		}

		public class TwitterSymbol
		{
			[JsonProperty("text")]
			public string Text { get; private set; }
			[JsonProperty("indices")]
			public IList<int> Indices { get; private set; }
		}

		public class TwitterUserMention
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

		public class TwitterURL
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

		public class TwitterMedia
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
			public TwitterSizes Sizes { get; private set; }
		}

		public class TwitterDescription
		{
			[JsonProperty("urls")]
			public IList<TwitterURL> URLs { get; private set; }
		}
	}
}
