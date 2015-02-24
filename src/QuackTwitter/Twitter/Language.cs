using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterLanguage
	{
		[JsonProperty("code")]
		public string Code { get; private set; }
		[JsonProperty("name")]
		public string Name { get; private set; }
		[JsonProperty("status")]
		public string Status { get; private set; }
	}
}
