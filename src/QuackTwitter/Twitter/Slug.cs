using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterSlug
	{
		[JsonProperty("users")]
		public IList<TwitterUser> Users { get; private set; }
		[JsonProperty("size")]
		public int Size { get; private set; }
		[JsonProperty("slug")]
		public string Slug { get; private set; }
		[JsonProperty("name")]
		public string Name { get; private set; }
	}
}
