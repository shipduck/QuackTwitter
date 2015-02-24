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
		public IList<TwitterUser> UsersLookup(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("screen_name")
				|| parameters.ContainsKey("user_id"))
			{
				return JsonConvert.DeserializeObject<IList<TwitterUser>>(GET(Constants.UsersURL + "/lookup.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterUser UsersShow(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("user_id")
				|| parameters.ContainsKey("screen_name"))
			{
				return JsonConvert.DeserializeObject<TwitterUser>(GET(Constants.UsersURL + "/show.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public IList<TwitterUser> UsersSearch(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("q"))
			{
				return JsonConvert.DeserializeObject<IList<TwitterUser>>(GET(Constants.UsersURL + "/search.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterBannerSizes UsersProfileBanner(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("user_id")
				|| parameters.ContainsKey("screen_name"))
			{
				return JsonConvert.DeserializeObject<TwitterBannerSizes>(GET(Constants.UsersURL + "/profile_banner.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterSlug UsersSuggestionsSlug(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("slug"))
			{
				return JsonConvert.DeserializeObject<TwitterSlug>(GET(Constants.UsersURL + "/suggestions/" + parameters["slug"] + ".json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public IList<TwitterSlug> UsersSuggestions(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<IList<TwitterSlug>>(GET(Constants.UsersURL + "/suggestions.json", parameters));
		}

		public IList<TwitterUser> UsersSuggestionsSlugMembers(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("slug"))
			{
				return JsonConvert.DeserializeObject<IList<TwitterUser>>(GET(Constants.UsersURL + "/suggestions/" + parameters["slug"] + "/members.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterUser UsersReportSpam(Dictionary<string, string> parameters)
		{
			if(parameters.ContainsKey("screen_name")
				|| parameters.ContainsKey("user_id"))
			{
				return JsonConvert.DeserializeObject<TwitterUser>(POST(Constants.UsersURL + "/report_spam.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}
	}
}
