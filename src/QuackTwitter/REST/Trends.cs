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
        public TwitterTrends TrendsPlace(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<TwitterTrends>(GET(Constants.TrendsURL + "/place.json", parameters));
        }

        public IList<TwitterTrendLocation> TrendsAvailable(Dictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterTrendLocation>>(GET(Constants.TrendsURL + "/available.json", parameters));
        }

        public IList<TwitterTrendLocation> TrendsClosest(Dictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, Utils.And("lat", "long"));

            return JsonConvert.DeserializeObject<IList<TwitterTrendLocation>>(GET(Constants.TrendsURL + "/closest.json", parameters));
        }
    }
}
