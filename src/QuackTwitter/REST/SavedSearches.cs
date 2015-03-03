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
        public IList<TwitterSavedSearch> SavedSearchesList(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterSavedSearch>>(GET(Constants.SavedSearchesURL + "/list.json", parameters));
        }

        public TwitterSavedSearch SavedSearchesShowId(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<TwitterSavedSearch>(GET(Constants.SavedSearchesURL + "/show/" + parameters["id"] + ".json", parameters));
        }

        public TwitterSavedSearch SavedSearchesCreate(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "query");

            return JsonConvert.DeserializeObject<TwitterSavedSearch>(POST(Constants.SavedSearchesURL + "/create.json", parameters));
        }

        public TwitterSavedSearch SavedSearchesDestroyId(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<TwitterSavedSearch>(POST(Constants.SavedSearchesURL + "/destroy/" + parameters["id"] + ".json", parameters));
        }
    }
}
