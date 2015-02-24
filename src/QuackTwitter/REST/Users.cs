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
		public interface ITwitterUsers
		{
			IList<TwitterUser> Lookup(Dictionary<string, string> parameters);
			TwitterUser Show(Dictionary<string, string> parameters);
			IList<TwitterUser> Search(Dictionary<string, string> parameters);
//			Dictionary<string, Size> ProfileBanner(Dictionary<string, string> paramters);
//			void SuggestionsSlug();
//			void Suggestions();
//			void SuggestionsSlugMemebers();
		}

		private class TwitterUsers : ITwitterUsers
		{
			private Twitter instance;
			public TwitterUsers(Twitter instance)
			{
				this.instance = instance;
			}

			public IList<TwitterUser> Lookup(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("screen_name")
					|| parameters.ContainsKey("user_id"))
				{
					return JsonConvert.DeserializeObject<IList<TwitterUser>>(instance.Get(Constants.UsersURL + "/lookup.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

			public TwitterUser Show(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("user_id")
					|| parameters.ContainsKey("screen_name"))
				{
					return JsonConvert.DeserializeObject<TwitterUser>(instance.Get(Constants.UsersURL + "/show.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

			public IList<TwitterUser> Search(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("q"))
				{
					return JsonConvert.DeserializeObject<IList<TwitterUser>>(instance.Get(Constants.UsersURL + "/search.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

//			public Dictionary<string, Size> ProfileBanner(Dictionary<string, string> paramters) {}
		}
	}
}
