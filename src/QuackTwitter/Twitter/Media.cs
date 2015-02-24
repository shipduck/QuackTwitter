using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterMedia
	{
		[JsonProperty("media_id")]
		public long MediaId { get; private set; }
		[JsonProperty("media_id_string")]
		public string MediaIdString { get; private set; }
		[JsonProperty("size")]
		public long Size { get; private set; }
		[JsonProperty("image")]
		public TwitterMediaImage Image { get; private set; }

		public class TwitterMediaImage
		{
			[JsonProperty("w")]
			public int Width { get; private set; }
			[JsonProperty("h")]
			public int Height { get; private set; }
			[JsonProperty("image_type")]
			public string ImageType { get; private set; }
		}
	}
}
