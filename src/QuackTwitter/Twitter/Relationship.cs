using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterRelationship
	{
		[JsonProperty("source")]
		public TwitterRelationshipUser Source { get; private set; }
		[JsonProperty("target")]
		public TwitterRelationshipUser Target { get; private set; }
	}
}
