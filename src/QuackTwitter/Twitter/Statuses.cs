using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class Twitter
	{
		public enum Statuses
		{
			MentionsTimeline,
			UserTimeline,
			HomeTimeline,
			RetweetsOfMe,
			Retweets,
			Show,
			Destroy,
			Update,
			Retweet,
			UpdateWithMedia,
			Oembed,
			Retweeters,
			Lookup
		};

		public dynamic REST(Statuses type, Dictionary<String, String> parameters)
		{
			switch (type)
			{
				case Statuses.MentionsTimeline:
					return Get(Constants.StatusesUrl + "/mentions_timeline.json", parameters);
				case Statuses.UserTimeline:
					return Get(Constants.StatusesUrl + "/user_timeline.json", parameters);
				case Statuses.HomeTimeline:
					return Get(Constants.StatusesUrl + "/home_timeline.json", parameters);
				case Statuses.RetweetsOfMe:
					return Get(Constants.StatusesUrl + "/retweets_of_me.json", parameters);
				case Statuses.Retweets:
					if (parameters.ContainsKey("id"))
					{
						return Get(Constants.StatusesUrl + "/retweets/" + parameters["id"] + ".json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Statuses.Show:
					if (parameters.ContainsKey("id"))
					{
						return Get(Constants.StatusesUrl + "/show.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Statuses.Destroy:
					if (parameters.ContainsKey("id"))
					{
						return Post(Constants.StatusesUrl + "/destroy/" + parameters["id"] + ".json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Statuses.Update:
					if (parameters.ContainsKey("status"))
					{
						return Post(Constants.StatusesUrl + "/update.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Statuses.Retweet:
					if (parameters.ContainsKey("id"))
					{
						return Post(Constants.StatusesUrl + "/retweet/" + parameters["id"] + ".json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Statuses.UpdateWithMedia:
					throw new Exception();
				case Statuses.Oembed:
					throw new Exception();
				case Statuses.Retweeters:
					if (parameters.ContainsKey("id"))
					{
						return Get(Constants.StatusesUrl + "/retweeters/ids.json", parameters);
					}
					else
					{
						throw new Exception();
					}
				case Statuses.Lookup:
					if (parameters.ContainsKey("id"))
					{
						return Get(Constants.StatusesUrl + "/lookup.json", parameters);
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
