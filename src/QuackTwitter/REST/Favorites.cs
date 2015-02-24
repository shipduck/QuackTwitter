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
		public class TwitterFavorites
		{
			private Twitter instance;
			public TwitterFavorites(Twitter instance)
			{
				this.instance = instance;
			}

			public IList<TwitterStatus> List(Dictionary<string, string> parameters = null)
			{
				return JsonConvert.DeserializeObject<IList<TwitterStatus>>(instance.Get(Constants.FavoritesURL + "/list.json", parameters));
			}

			public TwitterStatus Destroy(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("id"))
				{
					return JsonConvert.DeserializeObject<TwitterStatus>(instance.Post(Constants.FavoritesURL + "/destroy.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

			public TwitterStatus Create(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("id"))
				{
					return JsonConvert.DeserializeObject<TwitterStatus>(instance.Post(Constants.FavoritesURL + "/create.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}
		}
	}
}
