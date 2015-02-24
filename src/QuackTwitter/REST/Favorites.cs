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
		public IList<TwitterStatus> FavoritesList(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.FavoritesURL + "/list.json", parameters));
		}

		public TwitterStatus FavoritesDestroy(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("id"))
			{
				return JsonConvert.DeserializeObject<TwitterStatus>(POST(Constants.FavoritesURL + "/destroy.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterStatus FavoritesCreate(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("id"))
			{
				return JsonConvert.DeserializeObject<TwitterStatus>(POST(Constants.FavoritesURL + "/create.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}
	}
}
