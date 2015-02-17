﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class Twitter
	{
		public enum Geo
		{
			Id,
			ReverseGeocode,
			Search
		};

		public dynamic REST(Geo type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case Geo.Id:
					if (parameters.ContainsKey("place_id"))
					{
						return Get(Constants.GeoUrl + "/id/" + parameters["place_id"] + ".json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Geo.ReverseGeocode:
					if (parameters.ContainsKey("lat") && parameters.ContainsKey("long"))
					{
						return Get(Constants.GeoUrl + "/reverse_geocode.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Geo.Search:
					if ((parameters.ContainsKey("lat") && parameters.ContainsKey("long"))
						|| parameters.ContainsKey("ip")
						|| parameters.ContainsKey("query"))
					{
						return Get(Constants.GeoUrl + "/search.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				default:
					throw new Exception();
			}
		}
	}
}
