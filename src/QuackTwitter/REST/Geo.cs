using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class Twitter
	{
		public TwitterPlace GeoIdPlaceId(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("place_id"))
			{
				return JsonConvert.DeserializeObject<TwitterPlace>(GET(Constants.GeoURL + "/id/" + parameters["place_id"] + ".json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterGeo GeoReverseGeocode(Dictionary<string, string> parameters)
		{
			if(parameters.ContainsKey("lat")
				&& parameters.ContainsKey("long"))
			{
				return JsonConvert.DeserializeObject<TwitterGeo>(GET(Constants.GeoURL + "/reverse_geocode.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterGeo GeoSearch(Dictionary<string, string> parameters)
		{
			if((parameters.ContainsKey("lat") && parameters.ContainsKey("long"))
				|| parameters.ContainsKey("query")
				|| parameters.ContainsKey("ip")) {
					return JsonConvert.DeserializeObject<TwitterGeo>(GET(Constants.GeoURL + "/search.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}
	}
}
