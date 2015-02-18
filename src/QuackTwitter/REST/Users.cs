using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class QuackTwitter
	{
		public enum Users
		{
			Lookup,
			Show,
			Search,
			ProfileBanner,
			SuggestionsSlug,
			Suggestions,
			SuggestionsSlugMembers,
			ReportSpam
		};

		public dynamic REST(Users type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case Users.Lookup:
					return Get(Constants.UsersUrl + "lookup.json", parameters);
				case Users.Show:
					if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
					{
						return Get(Constants.UsersUrl + "show.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Users.Search:
					if (parameters.ContainsKey("q"))
					{
						return Get(Constants.UsersUrl + "search.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Users.ProfileBanner:
					if (parameters.ContainsKey("user_id")
						|| parameters.ContainsKey("screen_name"))
					{
						return Get(Constants.UsersUrl + "profile_banner.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Users.SuggestionsSlug:
					if (parameters.ContainsKey("slug"))
					{
						return Get(Constants.UsersUrl + "suggestions/" + parameters["slug"] + ".json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Users.Suggestions:
					return Get(Constants.UsersUrl + "suggestions.json", parameters);
				case Users.SuggestionsSlugMembers:
					return Get(Constants.UsersUrl + "suggestions/" + parameters["slug"] + "/members.json", parameters);
				case Users.ReportSpam:
					return Post(Constants.UsersUrl + "report_spam.json", parameters);
				default:
					throw new Exception();
			}
		}
	}
}
