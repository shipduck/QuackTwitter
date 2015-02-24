using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	partial class Twitter {
		public class TwitterStatuses
		{
			private Twitter instance;
			public TwitterStatuses(Twitter instance)
			{
				this.instance = instance;
			}

			public IList<TwitterStatus> MentionsTimeline(Dictionary<string, string> parameters = null)
			{
				return JsonConvert.DeserializeObject<IList<TwitterStatus>>(instance.Get(Constants.StatusesURL + "/mentions_timeline.json", parameters));
			}

			public IList<TwitterStatus> UserTimeline(Dictionary<string, string> parameters = null)
			{
				return JsonConvert.DeserializeObject<IList<TwitterStatus>>(instance.Get(Constants.StatusesURL + "/user_timeline.json", parameters));
			}

			public IList<TwitterStatus> HomeTimeline(Dictionary<string, string> parameters = null)
			{
				return JsonConvert.DeserializeObject<IList<TwitterStatus>>(instance.Get(Constants.StatusesURL + "/home_timeline.json", parameters));
			}

			public IList<TwitterStatus> RetweetsOfMe(Dictionary<string, string> parameters = null)
			{
				return JsonConvert.DeserializeObject<IList<TwitterStatus>>(instance.Get(Constants.StatusesURL + "/retweets_of_me.json", parameters));
			}

			public IList<TwitterStatus> Retweets(Dictionary<string, string> parameters = null)
			{
				if(parameters.ContainsKey("id")) {
					return JsonConvert.DeserializeObject<IList<TwitterStatus>>(instance.Get(Constants.StatusesURL + "/retweets/" + parameters["id"] + ".json", parameters));
				}
				else {
					throw new Exception();
				}
			}

			public TwitterStatus Show(Dictionary<string, string> parameters = null)
			{
				if (parameters.ContainsKey("id")) {
					return JsonConvert.DeserializeObject<TwitterStatus>(instance.Get(Constants.StatusesURL + "/show.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

			public TwitterStatus Destroy(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("id"))
				{
					return JsonConvert.DeserializeObject<TwitterStatus>(instance.Post(Constants.StatusesURL + "/destroy/" + parameters["id"] + ".json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

			public TwitterStatus Update(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("status"))
				{
					return JsonConvert.DeserializeObject<TwitterStatus>(instance.Post(Constants.StatusesURL + "/update.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

			public TwitterStatus Retweet(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("id"))
				{
					return JsonConvert.DeserializeObject<TwitterStatus>(instance.Post(Constants.StatusesURL + "/retweet/" + parameters["id"] + ".json", parameters));
				}
				else{
					throw new Exception();
				}
			}

			public TwitterStatus UpdateWithMedia(Dictionary<string, string> parameters)
			{
				if(parameters.ContainsKey("status")
					&& parameters.ContainsKey("media[]"))
				{
					return JsonConvert.DeserializeObject<TwitterStatus>(instance.Post(Constants.StatusesURL + "/update_with_media.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

//			public OEmbed OEmbed(Dictionary<string, string> parameters) {}

			public TwitterUserIds RetweetersIds(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("id"))
				{
					return JsonConvert.DeserializeObject<TwitterUserIds>(instance.Get(Constants.StatusesURL + "/retweeters/ids.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

			public IList<TwitterStatus> Lookup(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("id"))
				{
					return JsonConvert.DeserializeObject<IList<TwitterStatus>>(instance.Get(Constants.StatusesURL + "/lookup.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}
		}
	}
}
