using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class Twitter {
		public IList<TwitterStatus> StatusesMentionsTimeline(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/mentions_timeline.json", parameters));
		}

		public IList<TwitterStatus> StatusesUserTimeline(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/user_timeline.json", parameters));
		}

		public IList<TwitterStatus> StatusesHomeTimeline(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/home_timeline.json", parameters));
		}

		public IList<TwitterStatus> StatusesRetweetsOfMe(Dictionary<string, string> parameters = null)
		{
			return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/retweets_of_me.json", parameters));
		}

		public IList<TwitterStatus> StatusesRetweets(Dictionary<string, string> parameters = null)
		{
			if(parameters.ContainsKey("id")) {
				return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/retweets/" + parameters["id"] + ".json", parameters));
			}
			else {
				throw new Exception();
			}
		}

		public TwitterStatus StatusesShow(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("id")) {
				return JsonConvert.DeserializeObject<TwitterStatus>(GET(Constants.StatusesURL + "/show.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterStatus StatusesDestroy(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("id"))
			{
				return JsonConvert.DeserializeObject<TwitterStatus>(POST(Constants.StatusesURL + "/destroy/" + parameters["id"] + ".json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterStatus StatusesUpdate(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("status"))
			{
				return JsonConvert.DeserializeObject<TwitterStatus>(POST(Constants.StatusesURL + "/update.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public TwitterStatus StatusesRetweet(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("id"))
			{
				return JsonConvert.DeserializeObject<TwitterStatus>(POST(Constants.StatusesURL + "/retweet/" + parameters["id"] + ".json", parameters));
			}
			else{
				throw new Exception();
			}
		}

		public TwitterStatus StatusesUpdateWithMedia(Dictionary<string, string> parameters)
		{
			if(parameters.ContainsKey("status")
				&& parameters.ContainsKey("media[]"))
			{
				return JsonConvert.DeserializeObject<TwitterStatus>(POST(Constants.StatusesURL + "/update_with_media.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

//		public TwitterOEmbed StatusesOEmbed(Dictionary<string, string> parameters) {}

		public TwitterUserIds StatusesRetweetersIds(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("id"))
			{
				return JsonConvert.DeserializeObject<TwitterUserIds>(GET(Constants.StatusesURL + "/retweeters/ids.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}

		public IList<TwitterStatus> StatusesLookup(Dictionary<string, string> parameters)
		{
			if (parameters.ContainsKey("id"))
			{
				return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.StatusesURL + "/lookup.json", parameters));
			}
			else
			{
				throw new Exception();
			}
		}
	}
}
