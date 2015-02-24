using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterConfiguration
	{
		[JsonProperty("characters_reserved_per_media")]
		public int CharactersReservedPerMedia { get; private set; }
		[JsonProperty("max_media_per_upload")]
		public int MaxMediaPerUpload { get; private set; }
		[JsonProperty("non_username_paths")]
		public IList<string> NonUsernamePaths { get; private set; }
		[JsonProperty("photo_size_limit")]
		public long PhotoSizeLimit { get; private set; }
		[JsonProperty("photo_sizes")]
		public TwitterSizes PhotoSizes { get; private set; }
		[JsonProperty("short_url_length")]
		public int ShortURLLength { get; private set; }
		[JsonProperty("short_url_length_https")]
		public int ShortURLLengthHTTPS { get; private set; }
	}
}
