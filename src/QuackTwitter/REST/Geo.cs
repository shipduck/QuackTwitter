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
        public TwitterPlace GeoIdPlaceId(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "place_id");

            return JsonConvert.DeserializeObject<TwitterPlace>(GET(Constants.GeoURL + "/id/" + parameters["place_id"] + ".json", parameters));
        }

        async public Task<TwitterPlace> GeoIdPlaceIdAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "place_id");

            return JsonConvert.DeserializeObject<TwitterPlace>(await GETasync(Constants.GeoURL + "/id/" + parameters["place_id"] + ".json", parameters));
        }

        public TwitterGeo GeoReverseGeocode(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, Utils.And("lat", "long"));

            return JsonConvert.DeserializeObject<TwitterGeo>(GET(Constants.GeoURL + "/reverse_geocode.json", parameters));
        }

        async public Task<TwitterGeo> GeoReverseGeocodeAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, Utils.And("lat", "long"));

            return JsonConvert.DeserializeObject<TwitterGeo>(await GETasync(Constants.GeoURL + "/reverse_geocode.json", parameters));
        }

        public TwitterGeo GeoSearch(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, Utils.And("lat", "long"), "Queryable", "IProgress");

            return JsonConvert.DeserializeObject<TwitterGeo>(GET(Constants.GeoURL + "/search.json", parameters));
        }

        async public Task<TwitterGeo> GeoSearchAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, Utils.And("lat", "long"), "Queryable", "IProgress");

            return JsonConvert.DeserializeObject<TwitterGeo>(await GETasync(Constants.GeoURL + "/search.json", parameters));
        }
    }
}
