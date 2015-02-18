using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class QuackTwitter
	{
		public enum SavedSearches
		{
			List,
			Show,
			Create,
			Destroy
		};

		public dynamic REST(SavedSearches type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case SavedSearches.List:
					return Get(Constants.SavedSearchesUrl + "/list.json", parameters);
				case SavedSearches.Show:
					if (parameters.ContainsKey("id"))
					{
						return Get(Constants.SavedSearchesUrl + "/show/" + parameters["id"] + ".json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case SavedSearches.Create:
					if (parameters.ContainsKey("query"))
					{
						return Post(Constants.SavedSearchesUrl + "/create.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case SavedSearches.Destroy:
					if (parameters.ContainsKey("id"))
					{
						return Post(Constants.SavedSearchesUrl + "/destroy/" + parameters["id"] + ".json", parameters);
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
