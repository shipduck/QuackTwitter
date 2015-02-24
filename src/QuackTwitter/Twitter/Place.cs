using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterPlace
	{
		[JsonProperty("id")]
		public string Id { get; private set; }
		[JsonProperty("url")]
		public string URL { get; private set; }
		[JsonProperty("place_type")]
		public string PlaceType { get; private set; }
		[JsonProperty("name")]
		public string Name { get; private set; }
		[JsonProperty("full_name")]
		public string FullName { get; private set; }
		[JsonProperty("country_code")]
		public string CountryCode { get; private set; }
		[JsonProperty("country")]
		public string Country { get; private set; }
		[JsonProperty("contained_within")]
		public IList<TwitterPlace> ContainedWithin { get; private set; }
		[JsonProperty("bounding_box")]
		public TwitterBoundingBox BoundingBox { get; private set; }
		[JsonProperty("attributes")]
		public TwitterAttributes Attributes { get; private set; }

		public class TwitterBoundingBox
		{
			[JsonProperty("type")]
			public string Type { get; private set; }
			[JsonProperty("coordinates")]
			public IList<IList<IList<float>>> Coordinates { get; private set; }
		}

		public class TwitterAttributes
		{
			[JsonProperty("street_address")]
			public string StreetAddress { get; private set; }
			[JsonProperty("locality")]
			public string Localitiy { get; private set; }
			[JsonProperty("region")]
			public string Region { get; private set; }
			[JsonProperty("iso3")]
			public string ISO3 { get; private set; }
			[JsonProperty("postal_code")]
			public string PostalCode { get; private set; }
			[JsonProperty("phone")]
			public string Phone { get; private set; }
			[JsonProperty("twitter")]
			public string Twitter { get; private set; }
			[JsonProperty("url")]
			public string URL { get; private set; }
//			[JsonProperty("app:id")]
			public string Id { get; private set; }
		}
	}
}
