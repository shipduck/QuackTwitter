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
					return Get(Constants.UsersURL + "lookup.json", parameters);
				case Users.Show:
					if (parameters.ContainsKey("user_id") || parameters.ContainsKey("screen_name"))
					{
						return Get(Constants.UsersURL + "show.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Users.Search:
					if (parameters.ContainsKey("q"))
					{
						return Get(Constants.UsersURL + "search.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Users.ProfileBanner:
					if (parameters.ContainsKey("user_id")
						|| parameters.ContainsKey("screen_name"))
					{
						return Get(Constants.UsersURL + "profile_banner.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Users.SuggestionsSlug:
					if (parameters.ContainsKey("slug"))
					{
						return Get(Constants.UsersURL + "suggestions/" + parameters["slug"] + ".json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Users.Suggestions:
					return Get(Constants.UsersURL + "suggestions.json", parameters);
				case Users.SuggestionsSlugMembers:
					return Get(Constants.UsersURL + "suggestions/" + parameters["slug"] + "/members.json", parameters);
				case Users.ReportSpam:
					return Post(Constants.UsersURL + "report_spam.json", parameters);
				default:
					throw new Exception();
			}
		}
	}
}
