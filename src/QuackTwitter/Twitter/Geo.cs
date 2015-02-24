using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public class TwitterGeo
	{
		[JsonProperty("result")]
		public TwitterGeoResult Result { get; private set; }
		[JsonProperty("query")]
		public TwitterGeoQuery Query { get; private set; }

		public class TwitterGeoResult
		{
			[JsonProperty("places")]
			public IList<TwitterPlace> Places { get; private set; }
		}

		public class TwitterGeoQuery
		{
			[JsonProperty("url")]
			public string URL { get; private set; }
			[JsonProperty("type")]
			public string Type { get; private set; }
			[JsonProperty("params")]
			public TwitterGeoQueryParams Params { get; private set; }

			public class TwitterGeoQueryParams
			{
				[JsonProperty("accuracy")]
				public float Accuracy { get; private set; }
				[JsonProperty("coordinates")]
				public TwitterGeoQueryParamsCoordinates Coordinates { get; private set; }
				[JsonProperty("granularity")]
				public string Granularity { get; private set; }
				[JsonProperty("query")]
				public string Query { get; private set; }
				[JsonProperty("autocomplete")]
				public bool Autocomplete { get; private set; }
				[JsonProperty("trim_place")]
				public bool TrimPlace { get; private set; }

				public class TwitterGeoQueryParamsCoordinates
				{
					[JsonProperty("type")]
					public string Type { get; private set; }
					[JsonProperty("coordinates")]
					public IList<float> Coordinates { get; private set; }
				}
			}
		}
	}
}
