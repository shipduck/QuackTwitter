using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class Twitter
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
					return Get(Constants.SavedSearchesURL + "/list.json", parameters);
				case SavedSearches.Show:
					if (parameters.ContainsKey("id"))
					{
						return Get(Constants.SavedSearchesURL + "/show/" + parameters["id"] + ".json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case SavedSearches.Create:
					if (parameters.ContainsKey("query"))
					{
						return Post(Constants.SavedSearchesURL + "/create.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case SavedSearches.Destroy:
					if (parameters.ContainsKey("id"))
					{
						return Post(Constants.SavedSearchesURL + "/destroy/" + parameters["id"] + ".json", parameters);
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
