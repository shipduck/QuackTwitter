using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
	public partial class QuackTwitter
	{
		public interface ITwitterStatuses
		{
			IList<Status> MentionsTimeline(Dictionary<string, string> parameters = null);
			IList<Status> UserTimeline(Dictionary<string, string> parameters = null);
			IList<Status> HomeTimeline(Dictionary<string, string> paramters = null);
			IList<Status> RetweetsOfMe(Dictionary<string, string> parameters = null);
			IList<Status> Retweets(Dictionary<string, string> parameters);
			Status Show(Dictionary<string, string> parameters = null);
			Status Destroy(Dictionary<string, string> parameters);
			Status Update(Dictionary<string, string> parameters);
			Status Retweet(Dictionary<string, string> parameters);
			Status UpdateWithMedia(Dictionary<string, string> parameters);
//			OEmbed OEmbed(Dictionary<string, string> parameters);
			_Ids RetweetersIds(Dictionary<string, string> parameters);
			IList<Status> Lookup(Dictionary<string, string> parameters);
		}

		private class TwitterStatuses : ITwitterStatuses
		{
			private QuackTwitter instance;
			public TwitterStatuses(QuackTwitter instance)
			{
				this.instance = instance;
			}

			public IList<Status> MentionsTimeline(Dictionary<string, string> parameters = null)
			{
				return JsonConvert.DeserializeObject<IList<Status>>(instance.Get(Constants.StatusesURL + "/mentions_timeline.json", parameters));
			}

			public IList<Status> UserTimeline(Dictionary<string, string> parameters = null)
			{
				return JsonConvert.DeserializeObject<IList<Status>>(instance.Get(Constants.StatusesURL + "/user_timeline.json", parameters));
			}

			public IList<Status> HomeTimeline(Dictionary<string, string> parameters = null)
			{
				return JsonConvert.DeserializeObject<IList<Status>>(instance.Get(Constants.StatusesURL + "/home_timeline.json", parameters));
			}

			public IList<Status> RetweetsOfMe(Dictionary<string, string> parameters = null)
			{
				return JsonConvert.DeserializeObject<IList<Status>>(instance.Get(Constants.StatusesURL + "/retweets_of_me.json", parameters));
			}

			public IList<Status> Retweets(Dictionary<string, string> parameters = null)
			{
				if(parameters.ContainsKey("id")) {
					return JsonConvert.DeserializeObject<IList<Status>>(instance.Get(Constants.StatusesURL + "/retweets/" + parameters["id"] + ".json", parameters));
				}
				else {
					throw new Exception();
				}
			}

			public Status Show(Dictionary<string, string> parameters = null)
			{
				if (parameters.ContainsKey("id")) {
					return JsonConvert.DeserializeObject<Status>(instance.Get(Constants.StatusesURL + "/show.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

			public Status Destroy(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("id"))
				{
					return JsonConvert.DeserializeObject<Status>(instance.Post(Constants.StatusesURL + "/destroy/" + parameters["id"] + ".json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

			public Status Update(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("status"))
				{
					return JsonConvert.DeserializeObject<Status>(instance.Post(Constants.StatusesURL + "/update.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

			public Status Retweet(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("id"))
				{
					return JsonConvert.DeserializeObject<Status>(instance.Post(Constants.StatusesURL + "/retweet/" + parameters["id"] + ".json", parameters));
				}
				else{
					throw new Exception();
				}
			}

			public Status UpdateWithMedia(Dictionary<string, string> parameters)
			{
				if(parameters.ContainsKey("status")
					&& parameters.ContainsKey("media[]"))
				{
					return JsonConvert.DeserializeObject<Status>(instance.Post(Constants.StatusesURL + "/update_with_media.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

//			public OEmbed OEmbed(Dictionary<string, string> parameters) {}

			public _Ids RetweetersIds(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("id"))
				{
					return JsonConvert.DeserializeObject<_Ids>(instance.Get(Constants.StatusesURL + "/retweeters/ids.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}

			public IList<Status> Lookup(Dictionary<string, string> parameters)
			{
				if (parameters.ContainsKey("id"))
				{
					return JsonConvert.DeserializeObject<IList<Status>>(instance.Get(Constants.StatusesURL + "/lookup.json", parameters));
				}
				else
				{
					throw new Exception();
				}
			}
		}
	}
}
