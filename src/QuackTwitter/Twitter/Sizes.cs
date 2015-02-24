using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterSizes
	{
		[JsonProperty("thumb")]
		public TwitterSize Thumb { get; private set; }
		[JsonProperty("small")]
		public TwitterSize Small { get; private set; }
		[JsonProperty("medium")]
		public TwitterSize Medium { get; private set; }
		[JsonProperty("large")]
		public TwitterSize Large { get; private set; }

		public class TwitterSize
		{
			[JsonProperty("w")]
			public int Width { get; private set; }
			[JsonProperty("h")]
			public int Height { get; private set; }
			[JsonProperty("resize")]
			public string Resize { get; private set; }
		}
	}
}
