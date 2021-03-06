﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
    partial class Twitter
    {
        public TwitterTrends TrendsPlace(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<TwitterTrends>(GET(Constants.TrendsURL + "/place.json", parameters));
        }

        async public Task<TwitterTrends> TrendsPlaceAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<TwitterTrends>(await GETasync(Constants.TrendsURL + "/place.json", parameters));
        }

        public IList<TwitterTrendLocation> TrendsAvailable(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterTrendLocation>>(GET(Constants.TrendsURL + "/available.json", parameters));
        }

        async public Task<IList<TwitterTrendLocation>> TrendsAvailableAsync(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterTrendLocation>>(await GETasync(Constants.TrendsURL + "/available.json", parameters));
        }

        public IList<TwitterTrendLocation> TrendsClosest(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, Utils.And("lat", "long"));

            return JsonConvert.DeserializeObject<IList<TwitterTrendLocation>>(GET(Constants.TrendsURL + "/closest.json", parameters));
        }

        async public Task<IList<TwitterTrendLocation>> TrendsClosestAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, Utils.And("lat", "long"));

            return JsonConvert.DeserializeObject<IList<TwitterTrendLocation>>(await GETasync(Constants.TrendsURL + "/closest.json", parameters));
        }
    }
}
