using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterSavedSearch
	{
		[JsonProperty("created_at")]
		public string CreatedAt { get; private set; }
		[JsonProperty("id")]
		public long Id { get; private set; }
		[JsonProperty("position")]
		public bool Position { get; private set; }
		[JsonProperty("id_str")]
		public string IdStr { get; private set; }
		[JsonProperty("name")]
		public string Name { get; private set; }
	}
}
