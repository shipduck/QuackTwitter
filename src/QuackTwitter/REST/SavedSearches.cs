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
		public IList<TwitterSavedSearch> SavedSearchesList(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<IList<TwitterSavedSearch>>(GET(Constants.SavedSearchesURL + "/list.json", parameters));
		}

		public TwitterSavedSearch SavedSearchesShowId(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("id"))
			{
				return JsonConvert.DeserializeObject<TwitterSavedSearch>(GET(Constants.SavedSearchesURL + "/show/" + parameters["id"] + ".json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterSavedSearch SavedSearchesCreate(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("query"))
			{
				return JsonConvert.DeserializeObject<TwitterSavedSearch>(POST(Constants.SavedSearchesURL + "/create.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterSavedSearch SavedSearchesDestroyId(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("id"))
			{
				return JsonConvert.DeserializeObject<TwitterSavedSearch>(POST(Constants.SavedSearchesURL + "/destroy/" + parameters["id"] + ".json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}
	}
}
