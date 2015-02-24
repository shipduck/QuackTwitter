using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterTrendLocation
	{
		[JsonProperty("name")]
		public string Name { get; private set; }
		[JsonProperty("countryCode")]
		public string CountryCode { get; private set; }
		[JsonProperty("url")]
		public string URL { get; private set; }
		[JsonProperty("woeid")]
		public long WOEId { get; private set; }
		[JsonProperty("placeType")]
		public TwitterPlaceType PlaceType { get; private set; }
		[JsonProperty("parentid")]
		public long ParentId { get; private set; }
		[JsonProperty("country")]
		public string Country { get; private set; }

		public class TwitterPlaceType
		{
			[JsonProperty("name")]
			public string Name { get; private set; }
			[JsonProperty("code")]
			public int Code { get; private set; }
		}
	}
}
