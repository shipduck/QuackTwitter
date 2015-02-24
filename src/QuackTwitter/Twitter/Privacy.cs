using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterPrivacy
	{
		[JsonProperty("privacy")]
		public string Privacy { get; private set; }
	}
}
