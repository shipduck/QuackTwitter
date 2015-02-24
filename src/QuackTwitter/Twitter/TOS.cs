using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterTOS
	{
		[JsonProperty("tos")]
		public string TOS { get; private set; }
	}
}
